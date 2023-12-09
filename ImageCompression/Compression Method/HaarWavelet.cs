using ImageCompression.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCompression.Compression_Method
{
    public class HaarWavelet: Wavelet
    {
        public HaarWavelet(Picture image, CompressionSettings settings) : base(image, settings)
        {
        }

        private void LowHaarFilter(int x1, int y1, int x2, int y2, int hx, int hy)
        {
            WaveletMatrix[hx, hy].Cb = (yCbCr[x1, y1].Cb + yCbCr[x2, y2].Cb) / Math.Sqrt(2);
            WaveletMatrix[hx, hy].Cr = (yCbCr[x1, y1].Cr + yCbCr[x2, y2].Cr) / Math.Sqrt(2);
            WaveletMatrix[hx, hy].Y = (yCbCr[x1, y1].Y + yCbCr[x2, y2].Y) / Math.Sqrt(2);
        }
        private void HighHaarFilter(int x1, int y1, int x2, int y2, int hx, int hy)
        {
            WaveletMatrix[hx, hy].Cb = (yCbCr[x1, y1].Cb - yCbCr[x2, y2].Cb) / Math.Sqrt(2);
            WaveletMatrix[hx, hy].Cr = (yCbCr[x1, y1].Cr - yCbCr[x2, y2].Cr) / Math.Sqrt(2);
            WaveletMatrix[hx, hy].Y = (yCbCr[x1, y1].Y - yCbCr[x2, y2].Y) / Math.Sqrt(2);
        }
        private void HaarStrConversation()
        {
            var center = pic.Width / 2;
            for (int y = 0; y < pic.Height; y++)
            {
                for (int x = 0, l = 0; center + l < pic.Width; l++, x += 2)
                {
                    LowHaarFilter(x, y, x + 1, y, l, y);
                    HighHaarFilter(x, y, x + 1, y, center + l, y);
                }
            }
            ChangeMatrix();
        }
        private void HaarColumnConversation()
        {
            var center = pic.Height / 2;
            for (int x = 0; x < pic.Width; x++)
            {
                for (int y = 0, l = 0; y < pic.Height - 1; l++, y += 2)
                {
                    LowHaarFilter(x, y, x, y + 1, x, l);
                    HighHaarFilter(x, y, x, y + 1, x, center + l);
                }
            }
            ChangeMatrix();
        }
        private void HaarRevColumnConversation()
        {
            var center = pic.Height / 2;
            for (int x = 0; x < pic.Width; x++)
            {
                for (int y = 0, l = 0; center + l < pic.Height; l++, y += 2)
                {
                    LowHaarFilter(x, l, x, center + l, x, y);
                    HighHaarFilter(x, l, x, center + l, x, y + 1);
                }
            }
            ChangeMatrix();
        }
        private void HaarRevStrConversation()
        {
            var center = pic.Width / 2;
            for (int y = 0; y < pic.Height; y++)
            {
                for (int x = 0, l = 0; center + l < pic.Width; l++, x += 2)
                {
                    LowHaarFilter(l, y, center + l, y, x, y);
                    HighHaarFilter(l, y, center + l, y, x + 1, y);
                }
            }
            ChangeMatrix();
        }
        public void HaarConversation()
        {
            HaarStrConversation();
            HaarColumnConversation();
            Quantization(Settings.QuantCoef, true);
            ChangeMatrix();
            if (Settings.AdditionalCompression == true)
            {
                ResetToZero();
            }
            ToPicture();
        }
        public void HaarRevConversation()
        {
            Quantization(Settings.QuantCoef, false);
            HaarRevColumnConversation();
            HaarRevStrConversation();
            ToPicture();
            pic.RevBrghtnessShift();
            var newPicture = new Picture(pic.Height - Height, pic.Width - Width);
            for (int x = 0; x < newPicture.Width; x++)
            {
                for (int y = 0; y < newPicture.Height; y++)
                {
                    newPicture.Image[x, y] = pic.Image[x, y];
                }
            }
            pic = newPicture;
        }
    }
}
