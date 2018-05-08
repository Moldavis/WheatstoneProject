using System;
using System.Data;
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
            this.unknownResistor = 4000;
            InitializeComponent();
            SetDiagramText();
        }

        private void SetDiagramText()
        {
            this.resistorFirstLabel.Text = $"{this.valueRange / 5} Ohm";
            this.resistorSecondLabel.Text = $"{2 * this.valueRange / 5} Ohm";
            this.ResistorThirdLabel.Text = $"{3 * this.valueRange / 5} Ohm";
            this.resistorFourthLabel.Text = $"{4 * this.valueRange / 5} Ohm";
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
            FillValueTable();
        }

        private void FillValueTable()
        {
            var table = new DataTable();
            table.Columns.Add("resistor");
            table.Columns.Add("current");
            for (int i = 0; i < 10; i++)
            {
                var foo = table.NewRow();
                foo["resistor"] = i;
                foo["current"] = i * i;
                table.Rows.Add(foo);
            }

            dataGridValueTable.DataSource = table;
        }

        private void DrawCurve()
        {
            var points = CalculatePoints();
            var zeroPoint = points.FirstOrDefault(p => Math.Abs(p.Y - 250) < 0.1);

            var graphics = this.diagramBox.CreateGraphics();
            graphics.DrawCurve(new Pen(Color.Crimson), points);
            if (Math.Abs(zeroPoint.Y) > 0.01)
            {
                graphics.DrawLine(new Pen(Color.Black), 0, zeroPoint.Y, 500, zeroPoint.Y);
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
            try
            {
                if (e.KeyCode.Equals(Keys.Enter))
                {
                    this.unknownResistor = Convert.ToSingle(textBox2.Text);
                    textBox2.BackColor = Color.White;
                    if (this.checkBoxClearGraphs.Checked)
                    {
                        this.diagramBox.Refresh();
                    }
                    DrawCurve();
                }
            }
            catch (Exception exception)
            {
                textBox2.BackColor = Color.Red;
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode.Equals(Keys.Enter))
                {
                    this.valueRange = Convert.ToSingle(textBox1.Text);
                    this.diagramBox.Refresh();
                    textBox1.BackColor = Color.White;
                    SetDiagramText();
                    DrawCurve();
                }
            }
            catch (Exception exception)
            {
                textBox1.BackColor = Color.Red;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.unknownResistor = Convert.ToSingle(textBox2.Text);
                textBox2.BackColor = Color.White;
            }
            catch (Exception exception)
            {
                textBox2.BackColor = Color.Red;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.valueRange = Convert.ToSingle(textBox1.Text);
                SetDiagramText();
                textBox1.BackColor = Color.White;
            }
            catch (Exception exception)
            {
                textBox1.BackColor = Color.Red;
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
