using System;
using System.Data;
using System.Drawing;
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
            this.resistorFirstLabel.Text = $@"{this.valueRange / 5} Ohm";
            this.resistorSecondLabel.Text = $@"{2 * this.valueRange / 5} Ohm";
            this.ResistorThirdLabel.Text = $@"{3 * this.valueRange / 5} Ohm";
            this.resistorFourthLabel.Text = $@"{4 * this.valueRange / 5} Ohm";
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
            UpdateGraph();
        }

        private void UpdateGraph()
        {
            DrawCurve();
            FillValueTable();
            if (!this.dataGridValueTable.Visible)
            {
                dataGridValueTable.Visible = true;
            }
        }

        private void FillValueTable()
        {
            var calculator = new CurrentCalculator(this.unknownResistor, this.valueRange);
            var table = new DataTable();
            table.Columns.Add("resistor");
            table.Columns.Add("current");
            for (int i = 1; i <= 10; i++)
            {
                var foo = table.NewRow();
                foo["resistor"] = 50 * i * this.valueRange / 500;
                foo["current"] = calculator.CalculateCurrent(50 * i);
                table.Rows.Add(foo);
            }

            dataGridValueTable.DataSource = table;
        }

        private void DrawCurve()
        {
            var points = CalculatePoints();

            var graphics = this.diagramBox.CreateGraphics();
            graphics.DrawCurve(new Pen(Color.Crimson), points);
        }

        private PointF[] CalculatePoints()
        {
            var result = new PointF[500];
            var builder = new PointBuilder(new CurrentCalculator(this.unknownResistor, this.valueRange));
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
                    UpdateGraph();
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
                    UpdateGraph();
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
        private readonly CurrentCalculator currentCalculator;

        public PointBuilder(CurrentCalculator currentCalculator)
        {
            this.currentCalculator = currentCalculator;
        }

        public PointF Build(int iteration)
        {
            return new PointF
            {
                X = iteration,
                Y = 500 - (50 * this.currentCalculator.CalculateCurrent(iteration) + 250)
            };
        }
    }

    public class CurrentCalculator
    {
        private readonly float valueRange;
        private readonly float unknownResistor;

        public CurrentCalculator(float unknownResistor, float valueRange)
        {
            this.valueRange = valueRange;
            this.unknownResistor = unknownResistor;
        }

        public float CalculateCurrent(int iteration)
        {
            var variableResistor = iteration * this.valueRange / 500;
            const float baseCurrent = 10;
            const float staticResistor = 10000;
            return baseCurrent * ((staticResistor * this.unknownResistor - staticResistor * variableResistor) /
                                  ((staticResistor + staticResistor) * (this.unknownResistor + variableResistor)));
        }
    }
}
