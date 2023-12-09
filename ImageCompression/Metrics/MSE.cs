using ImageCompression.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace ImageCompression.Metrics
{
    public static partial class Metric
    {
        public static double MSE(Picture initPic,Picture convertPic)
        {
            double result = 0;
            for (var x = 0; x < initPic.Width; x++)//по оси x
            {
                for (var y = 0; y < initPic.Height; y++)//по оси y
                {
                    result += PxDiff(initPic.Image[x, y], convertPic.Image[x, y]);
                }
            }
            return result/(initPic.Height*initPic.Width*3);
        }
    }
}
