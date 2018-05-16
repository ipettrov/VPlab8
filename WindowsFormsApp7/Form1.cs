using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        private Timer timer;
        private BallDoc ballDoc;
        private Random random;
        public int generateBall { get; set; }




        public Form1()
        {
            InitializeComponent();
            generateBall = 0;
            ballDoc = new BallDoc();
            random = new Random();
            timer = new Timer();
            timer.Interval = 100;
            timer.Enabled = true;
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
            DoubleBuffered = true;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(generateBall%10 == 0)
            {
                int y = random.Next(2* Ball.RADIUS, this.Height - (Ball.RADIUS*2));
                int x = -Ball.RADIUS;
                ballDoc.addBall(new Point(x, y));
                generateBall++;
            }
            else
            {
                generateBall++;
                ballDoc.Move(this.Width);

            }
            Invalidate(true);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            ballDoc.Draw(e.Graphics);
          

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            ballDoc.Hit(e.Location);
            Invalidate(true);
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            ballDoc = new BallDoc();
            Invalidate(true);
        }

        private void statusStrip1_Paint(object sender, PaintEventArgs e)
        {
            toolStripStatusLabel1.Text = String.Format("Hits {0}", ballDoc.hits);
            toolStripStatusLabel2.Text = String.Format("Missed {0}", ballDoc.missed);

        }
    }
}
