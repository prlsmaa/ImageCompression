using ImageCompression.Common.ColorSpace;
using ImageCompression.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace ImageCompression.Compression_Method
{
    public class Wavelet
    {
        public Picture pic { get; set; }
        public YCbCr[,] yCbCr { get; set; }//Матрица значений пикселей изображения в  YCbCr
        public YCbCr[,] WaveletMatrix { get; set; }//Значения пикслей после преобразования
        public int Height { get; set; }//Разница пикселей по высоте
        public int Width { get; set; }//Разница пикселей по ширине
        public CompressionSettings Settings { get; set; }
        public Wavelet(Picture image,CompressionSettings settings)
        {
            //запомним разницу в пикселях 
            Height = (image.Height % 2 == 0) ? 0 : 1;
            Width = (image.Width % 2 == 0) ? 0 : 1;
            pic = new Picture(image.Height+Height, image.Width+Width);
            //дополняем недостающие пиксели по высоте и ширине
            for (var x = 0; x < image.Width; x++)
            {
                for (var y = 0; y < image.Height; y++)
                {
                    pic.Image[x, y] = new px();
                    if (image.Width % 2 != 0 && x == image.Width+Width - 1)
                    {
                        pic.Image[x, y] = y == image.Height+Height - 1 ? image.Image[x - 1, y - 1] : image.Image[x - 1, y];
                    }
                    else
                    {
                        pic.Image[x, y] = image.Height % 2 != 0 && y == image.Height + Height - 1 ? image.Image[x, y - 1] : image.Image[x, y];
                    }
                    pic.Image[x, y].r = image.Image[x, y].r;
                    pic.Image[x, y].g = image.Image[x, y].g;
                    pic.Image[x, y].b = image.Image[x, y].b;
                }
            }
            WaveletMatrix = new YCbCr[pic.Width, pic.Height];
            for (var x = 0; x < pic.Width; x++)
            {
                for (var y = 0; y < pic.Height; y++)
                {
                    WaveletMatrix[x, y] = new YCbCr();
                }
            }
            Settings = settings;
            pic.BrghtnessShift();
            yCbCr = pic.ToYCbCr(pic);
        }
        public void ResetToZero()//Дополнительное сжатие за счет обнуления нижнего правого квадрата пикселей
        {
            for (var x = pic.Width / 2 + 1; x < pic.Width; x++)
            {
                for (var y = pic.Height / 2 + 1; y < pic.Height; y++)
                {
                    yCbCr[x, y].Cr = 0;
                    yCbCr[x, y].Cb = 0;
                    //yCbCr[x, y].Y = 0;
                }
            }
        }
        public void ChangeMatrix() //Вспомогательный метод
        {
            for (var x = 0; x < pic.Width; x++)
            {
                for (var y = 0; y < pic.Height; y++)
                {
                    yCbCr[x, y].Cr = (int)WaveletMatrix[x, y].Cr;
                    yCbCr[x, y].Cb = (int)WaveletMatrix[x, y].Cb;
                    yCbCr[x, y].Y = (int)WaveletMatrix[x, y].Y;
                }
            }
        }
        private bool CheckZero(int x, int y,Picture copyPic)
        {
            return pic.Image[x, y].r.Equals(0) && !copyPic.Image[x, y].r.Equals(pic.Image[x, y].r) &&
                pic.Image[x, y].g.Equals(0) && !copyPic.Image[x, y].g.Equals(pic.Image[x, y].g) &&
                pic.Image[x, y].b.Equals(0) && !copyPic.Image[x, y].b.Equals(pic.Image[x, y].r);
        }
        public int Analisis(Picture copyPic)
        {
            var countZeros = 0;
            for (var x = 0; x < pic.Width-1; x++)
            {
                for (var y = 0; y < pic.Height-1; y++)
                {
                    if (CheckZero(x, y,copyPic)) countZeros++;
                }
            }
             return countZeros*100 / (pic.Width * pic.Height);
        }
        public Picture ToPicture()
        {
            Picture picture = new Picture(pic.Height, pic.Width);
            for (int x = 0; x < pic.Width; x++)
            {
                for (int y = 0; y < pic.Height; y++)
                {
                    pic.Image[x, y] = pic.Image[x, y].FromYCbCr(WaveletMatrix[x, y]);
                }
            }
            return picture;
        }
        public void Quantization(double coef, bool h)
        {
            for (var x = 0; x < pic.Width; x++)//по оси x
            {
                for (var y = 0; y < pic.Height; y++)//по оси y
                {
                    if (h)
                    {
                        WaveletMatrix[x, y].Cr = (int)(WaveletMatrix[x, y].Cr / coef);
                        WaveletMatrix[x, y].Cb = (int)(WaveletMatrix[x, y].Cb / coef);
                        WaveletMatrix[x, y].Y = (int)WaveletMatrix[x, y].Y;
                    }
                    else
                    {
                        yCbCr[x, y].Cr = (int)(yCbCr[x, y].Cr * coef);
                        yCbCr[x, y].Cb = (int)(yCbCr[x, y].Cb * coef);
                        yCbCr[x, y].Y = (int)yCbCr[x, y].Y;
                    }
                }
            }
        }
    }
}
