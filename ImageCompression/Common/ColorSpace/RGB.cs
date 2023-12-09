using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCompression.Common.ColorSpace
{
    public class px
    {
        public double r { get; set; }
        public double g { get; set; }
        public double b { get; set; }
        public static px operator +(px left, px right)
        {
            return new px
            {
                b = left.b + right.b,
                r = left.r + right.r,
                g = left.g + right.g
            };
        }
        public static px operator -(px left, px right)
        {
            return new px
            {
                b = left.b - right.b,
                r = left.r - right.r,
                g = left.g - right.g
            };
        }
        public static px operator /(px obj, double a)
        {
            return new px
            {
                b = obj.b / a,
                r = obj.r / a,
                g = obj.g / a
            };
        }
        public static px operator *(px obj, double a)
        {
            return new px
            {
                b = obj.b * a,
                r = obj.r * a,
                g = obj.g * a
            };
        }
        public px FromYCbCr(YCbCr obj)
        {
            return new px
            {
                //r = (int)(obj.Y + 1.402 * (obj.Cr - 128)),
                //g = (int)(obj.Y - 0.34414 * (obj.Cb - 128) - 0.71414 * (obj.Cr - 128)),
                //b = (int)(obj.Y + 1.772 * (obj.Cb - 128))
                r = (int)((obj.Y-16)* 0.00456621 + 0.00625893 * (obj.Cr - 128)),
                g = (int)((obj.Y-16) * 0.00456621 - 0.00153632 * (obj.Cb - 128) - 0.00318811 * (obj.Cr - 128)),
                b = (int)((obj.Y-16) * 0.00456621 + 0.00791071 * (obj.Cb - 128))
                //r = (int)(1.164*(obj.Y-16)+1.596*(obj.Cr-128)),
                //g = (int)(1.164 * (obj.Y - 16) - 0.813*(obj.Cr-128)-0.392*(obj.Cb-128)),
                //b = (int)(1.164 * (obj.Y - 16)+2.017*(obj.Cb-128))
            };
        }
    }
}
