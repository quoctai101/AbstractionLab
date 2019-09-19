using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionLab
{
    class Rectangle
    {
        private Point topleft, bottomright;
        public Point TopLeft
        {
            get { return topleft; }
            set { topleft = value; }
        }
        public Point BottomRight
        {
            get { return bottomright; }
            set { bottomright = value; }
        }
        public Rectangle(Point TopLeft, Point BottomRight)
        {
            topleft = TopLeft;
            bottomright = BottomRight;
        }
        public Rectangle(float TopLeftX, float TopLeftY, float BottomRightX, float BottomRightY)
            : this(new Point(TopLeftX, TopLeftY), new Point(BottomRightX, BottomRightY))
        {

        }
        public bool Contains(Point point)
        {
            if ((topleft.X <= point.X) && (point.X <= bottomright.X)
                && (topleft.Y <= point.Y) && (point.Y <= bottomright.Y))
                return true;
            else return false;
        }
    }
}
