using ImageCompression.Common.ColorSpace;
using ImageCompression.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCompression.Compression_Method
{
    public class DaubechiWavelet : Wavelet
    {
        double c0 = (1 + Math.Sqrt(3)) / (4 * Math.Sqrt(2));
        double c1 = (3 + Math.Sqrt(3)) / (4 * Math.Sqrt(2));
        double c2 = (3 - Math.Sqrt(3)) / (4 * Math.Sqrt(2));
        double c3 = (1 - Math.Sqrt(3)) / (4 * Math.Sqrt(2));
        public DaubechiWavelet(Picture image, CompressionSettings settings) : base(image, settings) {}

        public void HighDaubechiFilterStr(int x, int y, int l)
        {
            int x1 = x, x2 = x + 1, x3 = x + 2, x4 = x + 3;
            if (x == pic.Width - 2)
            {
                x1 = x;
                x2 = x + 1;
                x3 = 0;
                x4 = 1;
            }
            var Cr = c0 * yCbCr[x1, y].Cr + c1 * yCbCr[x2, y].Cr +
                         c2 * yCbCr[x3, y].Cr + c3 * yCbCr[x4, y].Cr;
            var Y = c0 * yCbCr[x1, y].Y + c1 * yCbCr[x2, y].Y +
                           c2 * yCbCr[x3, y].Y + c3 * yCbCr[x4, y].Y;
            var Cb = c0 * yCbCr[x1, y].Cb + c1 * yCbCr[x2, y].Cb +
                          c2 * yCbCr[x3, y].Cb + c3 * yCbCr[x4, y].Cb;
            WaveletMatrix[l, y].Cr = Cr;
            WaveletMatrix[l, y].Y = Y;
            WaveletMatrix[l, y].Cb = Cb;
        }
        public void LowDaubechiFilterStr(int x, int y, int dx, int dy)
        {
            int x1 = x, x2 = x + 1, x3 = x + 2, x4 = x + 3;
            if (x == pic.Width - 2)
            {
                x1 = x;
                x2 = x + 1;
                x3 = 0;
                x4 = 1;
            }
            var Cr = c3 * yCbCr[x1, y].Cr - c2 * yCbCr[x2, y].Cr +
                c1 * yCbCr[x3, y].Cr - c0 * yCbCr[x4, y].Cr;
            var Y = c3 * yCbCr[x1, y].Y - c2 * yCbCr[x2, y].Y +
                c1 * yCbCr[x3, y].Y - c0 * yCbCr[x4, y].Y;
            var Cb = c3 * yCbCr[x1, y].Cb - c2 * yCbCr[x2, y].Cb +
                c1 * yCbCr[x3, y].Cb - c0 * yCbCr[x4, y].Cb;
            WaveletMatrix[dx, dy].Cr = Cr;
            WaveletMatrix[dx, dy].Y = Y;
            WaveletMatrix[dx, dy].Cb = Cb;
        }
        public void HighDaubechiFilterColumn(int x, int y, int l)
        {
            int y1 = y, y2 = y + 1, y3 = y + 2, y4 = y + 3;
            if (y == pic.Height - 2)
            {
                y1 = y;
                y2 = y + 1;
                y3 = 0;
                y4 = 1;
            }
            var Cr = c0 * yCbCr[x, y1].Cr + c1 * yCbCr[x, y2].Cr +
                         c2 * yCbCr[x, y3].Cr + c3 * yCbCr[x, y4].Cr;
            var Y = c0 * yCbCr[x, y1].Y + c1 * yCbCr[x, y2].Y +
                           c2 * yCbCr[x, y3].Y + c3 * yCbCr[x, y4].Y;
            var Cb = c0 * yCbCr[x, y1].Cb + c1 * yCbCr[x, y2].Cb +
                          c2 * yCbCr[x, y3].Cb + c3 * yCbCr[x, y4].Cb;
            WaveletMatrix[x, l].Cr = Cr;
            WaveletMatrix[x, l].Y = Y;
            WaveletMatrix[x, l].Cb = Cb;
        }
        public void LowDaubechiFilterColumn(int x, int y, int dx, int dy)
        {
            int y1 = y, y2 = y + 1, y3 = y + 2, y4 = y + 3;
            if (y == pic.Height - 2)
            {
                y1 = y;
                y2 = y + 1;
                y3 = 0;
                y4 = 1;
            }
            var Cr = c3 * yCbCr[x, y1].Cr - c2 * yCbCr[x, y2].Cr +
                c1 * yCbCr[x, y3].Cr - c0 * yCbCr[x, y4].Cr;
            var Y = c3 * yCbCr[x, y1].Y - c2 * yCbCr[x, y2].Y +
                c1 * yCbCr[x, y3].Y - c0 * yCbCr[x, y4].Y;
            var Cb = c3 * yCbCr[x, y1].Cb - c2 * yCbCr[x, y2].Cb +
                c1 * yCbCr[x, y3].Cb - c0 * yCbCr[x, y4].Cb;
            WaveletMatrix[dx, dy].Cr = Cr;
            WaveletMatrix[dx, dy].Y = Y;
            WaveletMatrix[dx, dy].Cb = Cb;
        }
        private void DaubechiStrConversation()
        {
            var center = (pic.Width + 1) / 2;
            var l = 0;
            for (var y = 0; y < pic.Height; y++)
            {
                for (var x = 0; x < pic.Width; x += 2, l++)
                {
                    HighDaubechiFilterStr(x, y, l);
                    LowDaubechiFilterStr(x, y, center + l, y);
                }
                l = 0;
            }
            ChangeMatrix();
        }
        private void DaubechiColumnConversation()
        {
            var center = (pic.Height + 1) / 2;
            var l = 0;
            for (var x = 0; x < pic.Width; x++)
            {
                for (var y = 0; y < pic.Height; y += 2, l++)
                {
                    HighDaubechiFilterColumn(x, y, l);
                    LowDaubechiFilterColumn(x, y, x, center + l);
                }
                l = 0;
            }
            ChangeMatrix();
        }
        public void DaubechiConversation()
        {
            DaubechiStrConversation();
            DaubechiColumnConversation();
            Quantization(Settings.QuantCoef, true);
            ChangeMatrix();
            if (Settings.AdditionalCompression == true)
            {
                ResetToZero();
            }
            ToPicture();
        }
        public void DaubechiRevConversation()
        {
            Quantization(Settings.QuantCoef, false);
            RevDaubechiColumnConversation();
            RevDaubechiStrConversation();
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
        private void RevDaubechiColumnConversation()
        {
            var center = (pic.Height + 1) / 2; 
            var l = 0;
            for (var x = 0; x < pic.Width; x++)
            {
                for (var y = 0; center + l < pic.Height - 1; y += 2, l++)
                {
                    HighRevFilterColumn(x, l, center, l, y);
                    LowRevFilterColumn(x, l, center, l, y + 1);
                    if (y == 0) y += 2;
                }
                l = 0;
            }
            ChangeMatrix();
        }
        private void RevDaubechiStrConversation()
        {
            var center = (pic.Width + 1) / 2;
            var l = 0;
            for (var y = 0; y < pic.Height; y++)
            {
                for (var x = 0; center + l < pic.Width - 1; x += 2, l++)
                {
                    HighRevFilterStr(l, y, center, l, x);
                    LowRevFilterStr(l, y, center, l, x + 1);
                    if (x == 0) x += 2;
                }
                l = 0;
            }
            ChangeMatrix();
        }
        private void HighRevFilterStr(int x, int y, int s, int l, int x_)
        {
            double Cr, Y, Cb;
            if (x == 0)
            {
                Cr = c2 * yCbCr[s - 1, y].Cr + c1 * yCbCr[pic.Width - 1, y].Cr +
                             c0 * yCbCr[x, y].Cr + c3 * yCbCr[s, y].Cr;
                Y = c2 * yCbCr[s - 1, y].Y + c1 * yCbCr[pic.Width - 1, y].Y +
                           c0 * yCbCr[x, y].Y + c3 * yCbCr[s, y].Y;
                Cb = c2 * yCbCr[s - 1, y].Cb + c1 * yCbCr[pic.Width - 1, y].Cb +
                          c0 * yCbCr[x, y].Cb + c3 * yCbCr[s, y].Cb;
                WaveletMatrix[x_, y].Cr = Cr;
                WaveletMatrix[x_, y].Y = Y;
                WaveletMatrix[x_, y].Cb = Cb;
                Cr = c2 * yCbCr[x, y].Cr + c1 * yCbCr[s + l, y].Cr +
                             c0 * yCbCr[x + 1, y].Cr + c3 * yCbCr[s + l + 1, y].Cr;
                Y = c2 * yCbCr[x, y].Y + c1 * yCbCr[s + l, y].Y +
                           c0 * yCbCr[x + 1, y].Y + c3 * yCbCr[s + l + 1, y].Y;
                Cb = c2 * yCbCr[x, y].Cb + c1 * yCbCr[s + l, y].Cb +
                          c0 * yCbCr[x + 1, y].Cb + c3 * yCbCr[s + l + 1, y].Cb;
                WaveletMatrix[x_ + 2, y].Cr = Cr;
                WaveletMatrix[x_ + 2, y].Y = Y;
                WaveletMatrix[x_ + 2, y].Cb = Cb;
            }
            else
            {

                Cr = c2 * yCbCr[x, y].Cr + c1 * yCbCr[s + l, y].Cr +
                         c0 * yCbCr[x + 1, y].Cr + c3 * yCbCr[s + l + 1, y].Cr;
                Y = c2 * yCbCr[x, y].Y + c1 * yCbCr[s + l, y].Y +
                           c0 * yCbCr[x + 1, y].Y + c3 * yCbCr[s + l + 1, y].Y;
                Cb = c2 * yCbCr[x, y].Cb + c1 * yCbCr[s + l, y].Cb +
                          c0 * yCbCr[x + 1, y].Cb + c3 * yCbCr[s + l + 1, y].Cb;
                WaveletMatrix[x_, y].Cr = Cr;
                WaveletMatrix[x_, y].Y = Y;
                WaveletMatrix[x_, y].Cb = Cb;
            }

        }
        private void LowRevFilterStr(int l, int y, int s, int l_, int x_)
        {
            double Cr, Y, Cb;
            if (l == 0)
            {
                Cr = c3 * yCbCr[s - 1, y].Cr - c0 * yCbCr[pic.Width - 1, y].Cr +
                             c1 * yCbCr[l, y].Cr - c2 * yCbCr[s, y].Cr;
                Y = c3 * yCbCr[s - 1, y].Y - c0 * yCbCr[pic.Width - 1, y].Y +
                           c1 * yCbCr[l, y].Y - c2 * yCbCr[s, y].Y;
                Cb = c3 * yCbCr[s - 1, y].Cb - c0 * yCbCr[pic.Width - 1, y].Cb +
                          c1 * yCbCr[l, y].Cb - c2 * yCbCr[s, y].Cb;
                WaveletMatrix[x_, y].Cr = Cr;
                WaveletMatrix[x_, y].Y = Y;
                WaveletMatrix[x_, y].Cb = Cb;
                Cr = c3 * yCbCr[l, y].Cr - c0 * yCbCr[s + l_, y].Cr +
                         c1 * yCbCr[l + 1, y].Cr - c2 * yCbCr[s + l_ + 1, y].Cr;
                Y = c3 * yCbCr[l, y].Y - c0 * yCbCr[s + l_, y].Y +
                           c1 * yCbCr[l + 1, y].Y - c2 * yCbCr[s + l_ + 1, y].Y;
                Cb = c3 * yCbCr[l, y].Cb - c0 * yCbCr[s + l_, y].Cb +
                          c1 * yCbCr[l + 1, y].Cb - c2 * yCbCr[s + l_ + 1, y].Cb;
                WaveletMatrix[x_ + 2, y].Cr = Cr;
                WaveletMatrix[x_ + 2, y].Y = Y;
                WaveletMatrix[x_ + 2, y].Cb = Cb;
            }
            else
            {

                Cr = c3 * yCbCr[l, y].Cr - c0 * yCbCr[s + l_, y].Cr +
                         c1 * yCbCr[l + 1, y].Cr - c2 * yCbCr[s + l_ + 1, y].Cr;
                Y = c3 * yCbCr[l, y].Y - c0 * yCbCr[s + l_, y].Y +
                           c1 * yCbCr[l + 1, y].Y - c2 * yCbCr[s + l_ + 1, y].Y;
                Cb = c3 * yCbCr[l, y].Cb - c0 * yCbCr[s + l_, y].Cb +
                          c1 * yCbCr[l + 1, y].Cb - c2 * yCbCr[s + l_ + 1, y].Cb;
                WaveletMatrix[x_, y].Cr = Cr;
                WaveletMatrix[x_, y].Y = Y;
                WaveletMatrix[x_, y].Cb = Cb;
            }

        }
        private void HighRevFilterColumn(int x, int y, int s, int l, int y_)
        {
            double Cr, Y, Cb;
            if (y == 0)
            {
                Cr = c2 * yCbCr[x, s - 1].Cr + c1 * yCbCr[x, pic.Height - 1].Cr +
                             c0 * yCbCr[x, y].Cr + c3 * yCbCr[x, s].Cr;
                Y = c2 * yCbCr[x, s - 1].Y + c1 * yCbCr[x, pic.Height - 1].Y +
                           c0 * yCbCr[x, y].Y + c3 * yCbCr[x, s].Y;
                Cb = c2 * yCbCr[x, s - 1].Cb + c1 * yCbCr[x, pic.Height - 1].Cb +
                          c0 * yCbCr[x, y].Cb + c3 * yCbCr[x, s].Cb;
                WaveletMatrix[x, y_].Cr = Cr;
                WaveletMatrix[x, y_].Y = Y;
                WaveletMatrix[x, y_].Cb = Cb;
                Cr = c2 * yCbCr[x, y].Cr + c1 * yCbCr[x, s + l].Cr +
                             c0 * yCbCr[x, y + 1].Cr + c3 * yCbCr[x, s + l + 1].Cr;
                Y = c2 * yCbCr[x, y].Y + c1 * yCbCr[x, s + l].Y +
                           c0 * yCbCr[x, y + 1].Y + c3 * yCbCr[x, s + l + 1].Y;
                Cb = c2 * yCbCr[x, y].Cb + c1 * yCbCr[x, s + l].Cb +
                          c0 * yCbCr[x, y + 1].Cb + c3 * yCbCr[x, s + l + 1].Cb;
                WaveletMatrix[x, y_ + 2].Cr = Cr;
                WaveletMatrix[x, y_ + 2].Y = Y;
                WaveletMatrix[x, y_ + 2].Cb = Cb;
            }
            else
            {

                Cr = c2 * yCbCr[x, y].Cr + c1 * yCbCr[x, s + l].Cr +
                         c0 * yCbCr[x, y + 1].Cr + c3 * yCbCr[x, s + l + 1].Cr;
                Y = c2 * yCbCr[x, y].Y + c1 * yCbCr[x, s + l].Y +
                           c0 * yCbCr[x, y + 1].Y + c3 * yCbCr[x, s + l + 1].Y;
                Cb = c2 * yCbCr[x, y].Cb + c1 * yCbCr[x, s + l].Cb +
                          c0 * yCbCr[x, y + 1].Cb + c3 * yCbCr[x, s + l + 1].Cb;
                WaveletMatrix[x, y_].Cr = Cr;
                WaveletMatrix[x, y_].Y = Y;
                WaveletMatrix[x, y_].Cb = Cb;
            }


        }
        private void LowRevFilterColumn(int x, int l, int s, int l_, int y)
        {
            double Cr, Y, Cb;
            if (l == 0)
            {
                Cr = c3 * yCbCr[x, s - 1].Cr - c0 * yCbCr[x, pic.Height - 1].Cr +
                             c1 * yCbCr[x, l].Cr - c2 * yCbCr[x, s].Cr;
                Y = c3 * yCbCr[x, s - 1].Y - c0 * yCbCr[x, pic.Height - 1].Y +
                           c1 * yCbCr[x, l].Y - c2 * yCbCr[x, s].Y;
                Cb = c3 * yCbCr[x, s - 1].Cb - c0 * yCbCr[x, pic.Height - 1].Cb +
                          c1 * yCbCr[x, l].Cb - c2 * yCbCr[x, s].Cb;
                WaveletMatrix[x, y].Cr = Cr;
                WaveletMatrix[x, y].Y = Y;
                WaveletMatrix[x, y].Cb = Cb;
                Cr = c3 * yCbCr[x, l].Cr - c0 * yCbCr[x, s + l_].Cr +
                             c1 * yCbCr[x, l + 1].Cr - c2 * yCbCr[x, s + l_ + 1].Cr;
                Y = c3 * yCbCr[x, l].Y - c0 * yCbCr[x, s + l_].Y +
                           c1 * yCbCr[x, l + 1].Y - c2 * yCbCr[x, s + l_ + 1].Y;
                Cb = c3 * yCbCr[x, l].Cb - c0 * yCbCr[x, s + l_].Cb +
                          c1 * yCbCr[x, l + 1].Cb - c2 * yCbCr[x, s + l_ + 1].Cb;
                WaveletMatrix[x, y + 2].Cr = Cr;
                WaveletMatrix[x, y + 2].Y = Y;
                WaveletMatrix[x, y + 2].Cb = Cb;
            }
            else
            {


                Cr = c3 * yCbCr[x, l].Cr - c0 * yCbCr[x, s + l_].Cr +
                         c1 * yCbCr[x, l + 1].Cr - c2 * yCbCr[x, s + l_ + 1].Cr;
                Y = c3 * yCbCr[x, l].Y - c0 * yCbCr[x, s + l_].Y +
                           c1 * yCbCr[x, l + 1].Y - c2 * yCbCr[x, s + l_ + 1].Y;
                Cb = c3 * yCbCr[x, l].Cb - c0 * yCbCr[x, s + l_].Cb +
                          c1 * yCbCr[x, l + 1].Cb - c2 * yCbCr[x, s + l_ + 1].Cb;
                WaveletMatrix[x, y].Cr = Cr;
                WaveletMatrix[x, y].Y = Y;
                WaveletMatrix[x, y].Cb = Cb;

            }

        }
    }
}
