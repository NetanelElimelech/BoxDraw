using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxDraw
{
    class ZeroPoint
    {
        int xZero { get; set; }
        int yZero { get; set; }

        public ZeroPoint (double canvasWidth, double canvasHeight)
        {
            xZero = (int)canvasWidth;
            yZero = (int)canvasHeight;
        }
    }
}
