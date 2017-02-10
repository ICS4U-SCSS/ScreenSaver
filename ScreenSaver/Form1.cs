using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenSaver
{
    public partial class Form1 : Form
    {
        //Lists for ball attributes
        List<int> ballSize = new List<int>();
        List<Rectangle> ballRec = new List<Rectangle>();
        List<Color> ballColor = new List<Color>();
        List<int> ballXSpeed = new List<int>();
        List<int> ballYSpeed = new List<int>();

        //Graphics Objects
        SolidBrush ballBrush;

        public Form1()
        {
            InitializeComponent();
            InitBallValues();
        }

        public void InitBallValues()
        {
            //set the start values for the size of each ball
            ballSize.Add(125);
            ballSize.Add(35);
            ballSize.Add(50);

            //create rectangles that outline the starting position, width, and height of each ball
            ballRec.Add(new Rectangle(100, 100, ballSize[0], ballSize[0]));
            ballRec.Add(new Rectangle(200, 50, ballSize[1], ballSize[1]));
            ballRec.Add(new Rectangle(400, 175, ballSize[2], ballSize[2]));

            //set the start values for the colour of each ball
            ballColor.Add(Color.FromArgb(255, 0, 0));
            ballColor.Add(Color.FromArgb(0, 255, 0));
            ballColor.Add(Color.FromArgb(0, 0, 255));

            //set the start x speed of each ball (- left, + right)
            ballXSpeed.Add(5);
            ballXSpeed.Add(-5);
            ballXSpeed.Add(5);

            //set the start y speed of each ball (- down, + up)
            ballYSpeed.Add(-5);
            ballYSpeed.Add(-5);
            ballYSpeed.Add(5);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //check each ball and move them based on their x and y speed
            for (int i = 0; i < ballXSpeed.Count(); i++)
            {
                ballRec[i] = new Rectangle(ballRec[i].X + ballXSpeed[i],
                    ballRec[i].Y + ballYSpeed[i],
                    ballRec[i].Width,
                    ballRec[i].Height);
            }

            //check for collision with wall and revese direction if its true
            for (int i = 0; i < ballXSpeed.Count(); i++)
            {
                // collision with left  or side
                if (ballRec[i].X < 0 || ballRec[i].X > this.Width - 25)
                {
                    ballXSpeed[i] *= -1;
                }

                // collision with top or bottom
                if (ballRec[i].Y < 0 || ballRec[i].Y > this.Height - 50)
                {
                    ballYSpeed[i] *= -1;
                }
            }

            // redraw the screen
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // for each ball update the brush to its colour and then draw it
            // at the location and size indicated by its rectangle
            for (int i = 0; i < ballXSpeed.Count(); i++)
            {
                ballBrush = new SolidBrush(ballColor[i]);
                e.Graphics.FillEllipse(ballBrush, ballRec[i]);
            }
        }
    }
}
