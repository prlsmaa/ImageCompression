using ImageCompression.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCompression.Metrics
{
    static public partial class Metric
    {
        static public double PSNR(Picture initPic, Picture convertPic)
        {
            return 20 * Math.Log10(255 / Math.Sqrt(Metric.MSE(initPic,convertPic)));
        }
    }
}
