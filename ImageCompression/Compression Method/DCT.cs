using ImageCompression.Common;
using ImageCompression.Common.ColorSpace;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace ImageCompression.Compression_Method
{
    public class DCT
    {
        public YCbCr[,] Picture { get; set; }
        public CompressionSettings CompressionSettings { get; set; }
        public int Width { get; set; }
        public int Height { get; set; } 
        private  int ChangeHeight { get; set; }
        private int ChangeWidth { get; set; }
        private int[,] QuantMatrix { get; set; }
        public DCT(Picture picture, CompressionSettings compressionSettings)
        {
            CompressionSettings = compressionSettings;
            Picture newPicture=new Picture(0,0);
            if (picture.Width%8!=0)
            {
                ChangeWidth = (8-picture.Width%8);
                ChangeHeight = 0;
                newPicture = new Picture(picture.Height, picture.Width+ChangeWidth);
                Height = picture.Height + ChangeHeight;
                Width = picture.Width + ChangeWidth;
            }
            if (picture.Height % 8 != 0)
            {
                ChangeHeight = (8-picture.Height % 8);
                ChangeWidth = 0;
                newPicture = new Picture(picture.Height+ChangeHeight, picture.Width);
                Height = picture.Height + ChangeHeight;
                Width = picture.Width + ChangeWidth;
            }
            if (picture.Width % 8 != 0 && picture.Height % 8 != 0)
            {
                ChangeHeight = (8 - picture.Height % 8);
                ChangeWidth = (8 - picture.Width % 8);
                newPicture = new Picture(picture.Height + ChangeHeight, picture.Width + ChangeWidth);
                Height = picture.Height + ChangeHeight;
                Width = picture.Width + ChangeWidth;
            }
            if (picture.Width%8==0 && picture.Height%8==0)
            {
                ChangeWidth = 0;
                ChangeHeight= 0;
                newPicture =new Picture(picture.Height,picture.Width);
                Height = picture.Height + ChangeHeight;
                Width = picture.Width + ChangeWidth;
            }
            for (var x = 0; x < picture.Width; x++)//по оси x
            {
                for (var y = 0; y < picture.Height; y++)//по оси y
                {
                    newPicture.Image[x, y] = picture.Image[x, y];
                }
            }

            if (picture.Width%8!=0)
            {
                for(var x = picture.Width-1;x<newPicture.Width-1;x++)
                {
                    for(var y = 0;y<picture.Height;y++)
                    {
                        newPicture.Image[x + 1, y] = newPicture.Image[x, y];
                    }
                }
            }
            if (picture.Height%8!=0)
            {
                for (var x = 0; x < picture.Width - 1; x++)
                {
                    for (var y = picture.Height-1; y < newPicture.Height-1; y++)
                    {
                        newPicture.Image[x, y+1] = newPicture.Image[x, y];
                    }
                }
            }
            if (picture.Height % 8 != 0 && picture.Width % 8 != 0)
            {
                
                for (var x = picture.Width-1; x < newPicture.Width-1; x++)//по оси x
                {
                    for (var y = picture.Height-1; y < newPicture.Height-1; y++)//по оси y
                    {
                        newPicture.Image[x + 1, y+1] = (newPicture.Image[x+1, y]+ newPicture.Image[x, y+1])/2.0;
                    }
                }
            }
            newPicture.BrghtnessShift();
            Picture = newPicture.ToYCbCr(newPicture);
        }  
        public Picture ToPicture()
        {
            Picture picture = new Picture(Height, Width);
            for(int x=0;x<Width;x++) 
            {
                for(int y=0;y<Height;y++) 
                {
                    picture.Image[x,y]= picture.Image[x, y].FromYCbCr(Picture[x,y]);
                }
            }
            picture.RevBrghtnessShift();
            return picture;
        }
        public double[,] RevDCT(double[,] m)
        {
            int N = 8;
            var revdct = new double[N, N];
            double a_x, a_y;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                   
                    double sum = 0;
                    for (int x = 0; x < N; x++)
                    {
                        for (int y = 0; y < N; y++)
                        {
                            if (x == 0)
                            {
                                a_x = Math.Sqrt(1.0 / N);
                            }
                            else
                            {
                                a_x = Math.Sqrt(2.0 / N);
                            }
                            if (y == 0)
                            {
                                a_y = Math.Sqrt(1.0 / N); ;
                            }
                            else
                            {
                                a_y = Math.Sqrt(2.0 / N);
                            }
                            var t = Math.Cos(((2 * i + 1) * x * Math.PI) / (2 * N));
                            var k = Math.Cos(((2 * j + 1) * y * Math.PI) / (2 * N));
                            sum += m[x, y] * t * k * a_x * a_y;
                        }
                    }
                    revdct[i, j] = sum;
                }
            }
            return revdct;
        }
        public double[,] CreateDCT(double[,] m)
        {
            int N = 8;
            var dct = new double[N, N];
            double a_i, a_j;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i == 0)
                    {
                        a_i = Math.Sqrt(1.0 / N);
                    }
                    else
                    {
                        a_i = Math.Sqrt(2.0 / N);
                    }
                    if (j == 0)
                    {
                        a_j = Math.Sqrt(1.0 / N); ;
                    }
                    else
                    {
                        a_j = Math.Sqrt(2.0 / N);
                    }
                    double sum = 0;
                    for (int x = 0; x < N; x++)
                    {
                        for (int y = 0; y < N; y++)
                        {
                            var t = Math.Cos(((2 * x + 1) * i * Math.PI) / (2 * N));
                            var k = Math.Cos(((2 * y + 1) * j * Math.PI) / (2 * N));
                            sum += m[x, y] * t * k;
                        }
                    }
                    dct[i, j] = sum * a_i * a_j;
                }
            }
            return dct;
        }
        public double[,] Quantization(double[,] m, double k, bool flag)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(flag==true)
                    {
                        m[i, j] = (int)m[i, j] / k;
                    }
                    else
                    {
                        m[i, j] = (int)m[i, j] * k;
                    }
                }
            }
            return m;
        }
        public void Conversation()
        {
            for (var x = 0; x <Width; x+=8)//по оси x
            {
                for (var y = 0; y < Height; y+=8)//по оси y
                {
                    double[,] Cb = new double[8, 8];
                    double[,] Cr = new double[8, 8];
                    for (int i=0;i<8;i++)
                    {
                        for(int j=0;j<8;j++)
                        {
                            Cb[i, j] = Picture[x + i, y + j].Cb;
                            Cr[i, j] = Picture[x + i, y + j].Cr;
                        }
                    }
                    double[,] CbDCT = CreateDCT(Cb);
                    double[,] CrDCT = CreateDCT(Cr);
                    CbDCT = Quantization(CbDCT, CompressionSettings.QuantCoef,true);
                    CrDCT = Quantization(CrDCT, CompressionSettings.QuantCoef,true);
                    
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            Picture[x + i, y + j].Cb = CbDCT[i, j];
                            Picture[x + i, y + j].Cr = CrDCT[i, j];
                        }
                    }
                }
            }

        }
        public Picture RevConversation()
        {
            for (var x = 0; x < Width; x += 8)//по оси x
            {
                for (var y = 0; y < Height; y += 8)//по оси y
                {
                    double[,] Cb = new double[8, 8];
                    double[,] Cr = new double[8, 8];
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            Cb[i, j] = Picture[x + i, y + j].Cb;
                            Cr[i, j] = Picture[x + i, y + j].Cr;
                        }
                    }
                    double[,] CbDCT = Quantization(Cb, CompressionSettings.QuantCoef,false);
                    double[,] CrDCT = Quantization(Cr, CompressionSettings.QuantCoef,false);
                    CbDCT = RevDCT(CbDCT);
                    CrDCT = RevDCT(CrDCT);
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            Picture[x + i, y + j].Cb = CbDCT[i, j];
                            Picture[x + i, y + j].Cr = CrDCT[i, j];
                        }
                    }
                }
            }
            var pic = ToPicture();
            
            var newPicture = new Picture(pic.Height - ChangeHeight, pic.Width - ChangeWidth);
            for (int x = 0; x < newPicture.Width; x++)
            {
                for (int y = 0; y < newPicture.Height; y++)
                {
                    newPicture.Image[x, y] = pic.Image[x, y];
                }
            }
            return newPicture;
        }
        public Bitmap ToBitmap()
        {
            var bitmapImage = new Bitmap(Width, Height);
            var pic = ToPicture();
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    byte red = SetPixelBMP(pic.Image[x, y].r);
                    byte green = SetPixelBMP(pic.Image[x, y].g);
                    byte blue = SetPixelBMP(pic.Image[x, y].b);
                    bitmapImage.SetPixel(x, y, Color.FromArgb(red, green, blue));

                }
            }
            return bitmapImage;
        }
        private byte SetPixelBMP(double px)
        {
            return (byte)(px > 255 ? 255 : px);
        }
    }
}
