
using ImageCompression.Common.ColorSpace;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ImageCompression.Common
{
    public class Picture
    {
        public px[,] Image;
        public int Height;
        public int Width;
        public Picture(Bitmap image)
        {
            Height = image.Height;
            Width = image.Width;
            Image = new px[Width, Height];

            for (var x = 0; x < Width; x++)//по оси x
            {
                for (var y = 0; y < Height; y++)//по оси y
                {
                    Image[x, y] = new px();
                    Color pixel = image.GetPixel(x, y);
                    Image[x, y].r = pixel.R;
                    Image[x, y].g = pixel.G;
                    Image[x, y].b = pixel.B;
                }
            }

        }
        public Picture(int height, int width)
        {
            Height = height;
            Width = width;
            Image = new px[Width, Height];
            for (var x = 0; x < Width; x++)//по оси x
            {
                for (var y = 0; y < Height; y++)//по оси y
                {
                    Image[x, y] = new px();
                }
            }
        }
        public void BrghtnessShift()
        {
            for (var x = 0; x < Width; x++)//по оси x
            {
                for (var y = 0; y < Height; y++)//по оси y
                {
                    Image[x, y].r = Image[x, y].r - 127;
                    Image[x, y].g = Image[x, y].g - 127;
                    Image[x, y].b = Image[x, y].b - 127;
                }
            }
        }
        public void RevBrghtnessShift()
        {
            for (var x = 0; x < Width; x++)//по оси x
            {
                for (var y = 0; y < Height; y++)//по оси y
                {
                    Image[x, y].r = Image[x, y].r + 127;
                    Image[x, y].g = Image[x, y].g + 127;
                    Image[x, y].b = Image[x, y].b + 127;
                }
            }
        }
        public YCbCr[,] ToYCbCr(Picture picture)
        {
            YCbCr[,] yCbCr = new YCbCr[picture.Width, picture.Height];
            for (var x = 0; x < picture.Width; x++)//по оси x
            {
                for (var y = 0; y < picture.Height; y++)//по оси y
                {
                    yCbCr[x, y] = new YCbCr();
                    yCbCr[x, y] = yCbCr[x, y].FromRGB(picture.Image[x, y]);
                }
            }
            return yCbCr;
        }
        public Bitmap ToBitmap()
        {
            var bitmapImage = new Bitmap(Width, Height);
            for (var x = 0; x < Width; x++)//по оси x
            {
                for (var y = 0; y < Height; y++)//по оси y
                {
                    byte red = SetPixelBMP(Image[x, y].r);
                    byte green = SetPixelBMP(Image[x, y].g);
                    byte blue = SetPixelBMP(Image[x, y].b);
                    bitmapImage.SetPixel(x, y, Color.FromArgb(red, green, blue));

                }
            }
            return bitmapImage;
        }
        private byte SetPixelBMP(double px)
        {
            if (px < 0) return 0;// (byte)Math.Abs(px);
            return (byte)(px > 255 ? 255 : px);
        }
    }
}
