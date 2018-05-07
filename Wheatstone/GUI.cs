using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Wheatstone
{
    public partial class GUI : Form
    {
        private float valueRange;
        private float unknownResistor;

        public GUI()
        {
            this.valueRange = 10000;
            this.unknownResistor = 6000;
            InitializeComponent();
        }

        private void diagramBox_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 1; i <= 5; i++)
            {
                e.Graphics.DrawLine(new Pen(Color.Beige, 1), i * 100, 0, i * 100, 500);
                e.Graphics.DrawLine(new Pen(Color.Beige, 1), 0, i * 100, 500, i * 100);
            }
            e.Graphics.DrawLine(new Pen(Color.Black, 1), 0, 250, 500, 250);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DrawCurve();
        }

        private void DrawCurve()
        {
            var points = CalculatePoints();
            var zeroPoint = points.FirstOrDefault(p => Math.Abs(p.Y - 250) < 0.1);

            var foo = this.diagramBox.CreateGraphics();
            foo.DrawCurve(new Pen(Color.Crimson), points);
            if (Math.Abs(zeroPoint.Y) > 0.01)
            {
                foo.DrawLine(new Pen(Color.Black), 0, zeroPoint.Y, 500, zeroPoint.Y);
            }
        }

        private PointF[] CalculatePoints()
        {
            var result = new PointF[500];
            var builder = new PointBuilder(this.valueRange, this.unknownResistor);
            for (int i = 0; i < 500; i++)
            {
                result[i] = builder.Build(i);
            }
            return result;
        }



        private void button3_Click(object sender, EventArgs e)
        {
            this.diagramBox.Invalidate();
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                this.unknownResistor = Convert.ToSingle(textBox2.Text);
                DrawCurve();
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                this.valueRange = Convert.ToSingle(textBox1.Text);
                DrawCurve();
            }
        }
    }

    public class PointBuilder
    {
        private readonly float valueRange;
        private readonly float unknownResistor;

        public PointBuilder(float valueRange, float unknownResistor)
        {
            this.valueRange = valueRange;
            this.unknownResistor = unknownResistor;
        }

        public PointF Build(int iteration)
        {
            return new PointF
            {
                X = iteration,
                Y = 500 - (50 * CalculateCurrent(iteration) + 250)
            };
        }

        private float CalculateCurrent(int iteration)
        {
            var variableResistor = iteration * this.valueRange / 500;
            const float baseCurrent = 10;
            const float staticResistor = 10000;
            return baseCurrent * ((staticResistor * this.unknownResistor - staticResistor * variableResistor) /
                                  ((staticResistor + staticResistor) * (this.unknownResistor + variableResistor)));
        }
    }
}
