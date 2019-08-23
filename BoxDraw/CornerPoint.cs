using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxDraw
{
    class CornerPoint
    {
        public enum LineType { hor, ver, dia}

        public int X { get; set; }
        public int Y { get; set; }
        public int zeroX { get; set; }
        public int zeroY { get; set; }

        public CornerPoint(int xValue1, int xValue2, int yValue1, int yValue2)
        {
            X = CalcX(xValue1, xValue2);
            Y = CalcY(yValue1, yValue2);
        }

        int CalcX(int value1, int value2)
        {
            if (value1 != value2)
            {
                if (value1 > value2)
                {
                    X = value1 - value2;
                }

                else
                {
                    X = value2 - value1;
                }
            }

            return X;
        }

        int CalcY(int value1, int value2)
        {
            if (value1 != value2)
            {
                if (value1 > value2)
                {
                    Y = value1 - value2;
                }

                else
                {
                    Y = value2 - value1;
                }
            }

            return Y;
        }

        private List<CornerPoint> CreateCornerPointsList()
        {
            List<CornerPoint> cornerPoints = new List<CornerPoint>();

            return cornerPoints;
        }

        void SetZeroPoint(int canvasHeight)
        {
            zeroX = 0;
            zeroY = canvasHeight;
        }



        private void CalcHorizontalLines(List<CornerPoint> CornerPoints)
        {

        }

        private void CalcVerticalLines()
        {

        }

        private void CalcDiagonalLines()
        {

        }
    }
}
