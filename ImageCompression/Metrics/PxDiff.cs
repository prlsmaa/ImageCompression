using ImageCompression.Common.ColorSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCompression.Metrics
{
    static public partial class Metric
    {
        static private double PxDiff(px initPx,px convertPx)
        {
            double diffR=initPx.r-convertPx.r;
            double diffG=initPx.g-convertPx.g;
            double diffB=initPx.b-convertPx.b;
            return (Math.Abs(diffR)* Math.Abs(diffR) + Math.Abs(diffG)* Math.Abs(diffG) + Math.Abs(diffB) * Math.Abs(diffB));
        }
    }
}
