using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp7
{
    [Serializable]
    public class BallDoc
    {
        public List<Ball> balls;
        public int hits { get; set; }
        public int missed { get; set; }
        public bool paused { get; set; }

        public BallDoc()
        {
            balls = new List<Ball>();
            hits = 0;
            missed = 0;
            paused = false;
        }

        public void addBall(Point center)
        {
            Ball b = new Ball(center);
            balls.Add(b);

        }

        public void Hit(Point point)
        {
            bool flag = false;
            for (int i=0;i<balls.Count;i++)
            {
                if (balls[i].Hit(point))
                {
                    if (balls[i].state == -1)
                        balls.RemoveAt(i);
                    this.hits++;
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                missed++;
            }
        }

        public void Move(int w)
        {
            if (!paused)
            {
                for (int i = 0; i < balls.Count; i++)
                {
                    balls[i].Move();
                    if (balls[i].point.X >= w + Ball.RADIUS)
                    {
                        balls.RemoveAt(i);
                    }
                }
            }
        }

        public void Draw(Graphics g)
        {
            foreach (Ball b in balls)
            {
                b.Draw(g);
            }
        }

    }
}
