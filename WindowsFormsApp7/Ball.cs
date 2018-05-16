using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp7
{
    [Serializable]
    public class Ball
    {
        public int state { get; set; }
        public static readonly int RADIUS = 30;
        public Point point { get; set; }

        public Ball(Point p)
        {
            this.point = p;
            Random r = new Random();
            state = r.Next(3);
        }

        public void Move()
        {
            point = new Point(point.X + 10, point.Y);
        }

        public bool Hit(Point position)
        {
            if (RADIUS * RADIUS >= (point.X - position.X) * (point.X - position.X) + (point.Y - position.Y) * (point.Y - position.Y))
            {
                state++;
                if(state == 3)
                {
                    state = -1;
                    
                }
                return true;
            }
            return false;

        }

        public void Draw(Graphics g)
        {
            Brush b = null;
            if(state == 0)
            {
                b = new SolidBrush(Color.Green);
            }
            else if (state == 1)
            {
                b = new SolidBrush(Color.Blue);
            }
            else
            {
                b = new SolidBrush(Color.Red);
            }
            g.FillEllipse(b, point.X - RADIUS, point.Y - RADIUS, RADIUS * 2,RADIUS*2);
            b.Dispose();

        }



    }
}
