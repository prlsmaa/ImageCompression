using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCompression.Common.ColorSpace
{
    public class YCbCr
    {
        public double Y { get; set; }
        public double Cb { get; set; }
        public double Cr { get; set; }
        public static YCbCr operator +(YCbCr left, YCbCr right)
        {
            return new YCbCr
            {
                Y = left.Y + right.Y,
                Cb = left.Cb + right.Cb,
                Cr = left.Cr + right.Cr
            };
        }
        public static YCbCr operator -(YCbCr left, YCbCr right)
        {
            return new YCbCr
            {
                Y = left.Y - right.Y,
                Cb = left.Cb - right.Cb,
                Cr = left.Cr - right.Cr
            };
        }
        public static YCbCr operator /(YCbCr obj, double a)
        {
            return new YCbCr
            {
                Y = obj.Y / a,
                Cb = obj.Cb / a,
                Cr = obj.Cr / a
            };
        }
        public static YCbCr operator *(YCbCr obj, double a)
        {
            return new YCbCr
            {
                Y = obj.Y * a,
                Cb = obj.Cb * a,
                Cr = obj.Cr * a
            };
        }
        public YCbCr FromRGB(px obj)
        {
            return new YCbCr
            {
                //Y = 0 + (0.299 * obj.r) + (0.587 * obj.g) + (0.114 * obj.b),
                //Cb = 128 - (0.168736 * obj.r) - (0.331264 * obj.g) + (0.5 * obj.b),
                //Cr = 128 + (0.5 * obj.r) - (0.418688 * obj.g) - (0.081312 * obj.b)
                Y =  (int)(16 + (65.481 * obj.r) + (128.553 * obj.g) + (24.966 * obj.b)),
                Cb = (int)(128 - (37.797 * obj.r) - (74.203 * obj.g) + (112 * obj.b)),
                Cr = (int)(128 + (112 * obj.r) - (93.786 * obj.g) - (18.214 * obj.b))
                //Y = (int)(16 + (0.257 * obj.r) + (0.504 * obj.g) + (0.098 * obj.b)),
                //Cb = (int)(128 - (0.148 * obj.r) - (0.291 * obj.g) + (0.439 * obj.b)),
                //Cr = (int)(128 + (0.439 * obj.r) - (0.368 * obj.g) - (0.071 * obj.b))
            };
        }
    }
}
