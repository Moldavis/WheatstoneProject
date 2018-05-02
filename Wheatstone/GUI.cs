using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Wheatstone
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawLine(0);
        }

        private void diagramBox_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 1; i <= 5; i++)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 1), i * 100, 0, i * 100, 500);
                e.Graphics.DrawLine(new Pen(Color.Black, 1), 0, i * 100, 500, i * 100);
            }
        }

        public void DrawLine(int bar)
        {
            var foo = this.diagramBox.CreateGraphics();
            foo.DrawLine(new Pen(Color.Black), bar, 0,500,500);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DrawCurve();
        }

        private void DrawCurve()
        {
            var points = CalculatePoints();
            var diffY = points[0].Y - points[499].Y;
            var lowestY = points[499].Y;

            for (int i = 0; i < 500; i++)
            {
                points[i].Y += (lowestY*-1);
                points[i].Y *= 500/diffY;
            }

            var foo = this.diagramBox.CreateGraphics();
            foo.DrawCurve(new Pen(Color.Aqua),points );
        }

        private PointF[] CalculatePoints()
        {
            var result = new PointF[500];
            for (int i = 0; i < 500; i++)
            {
                result[i] = new PointF(i,CalculateCurrent(i));
            }
            return result;
        }

        private float CalculateCurrent(int i)
        {
            float baseCurrent = 10;
            float staticResistor = 10000;
            float variableResistor = 6000;
            return baseCurrent * ((variableResistor * staticResistor - staticResistor * i*20) /
                                          ((variableResistor + staticResistor) * (staticResistor + i*20)));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.diagramBox.Invalidate();
        }
    }
}
