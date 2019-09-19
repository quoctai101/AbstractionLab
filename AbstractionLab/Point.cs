using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionLab
{
    class Point
    {
        private float x, y;
        public float X
        {
            get { return x; }
            set { x = value; }
        }
        public float Y
        {
            get { return y; }
            set { y = value; }
        }
        public Point(float X, float Y)
        {
            this.X = X; this.Y = Y;
        }
    }
}
