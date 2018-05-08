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
        private bool inputValid;

        public GUI()
        {
            this.valueRange = 10000;
            this.unknownResistor = 4000;
            this.inputValid = true;
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
                e.Graphics.DrawLine(new Pen(Color.Beige, 1), i * 100, 0, i * 100, this.diagramBox.Width);
                e.Graphics.DrawLine(new Pen(Color.Beige, 1), 0, i * 100, this.diagramBox.Height, i * 100);
            }
            e.Graphics.DrawLine(new Pen(Color.Black, 1), 0, this.diagramBox.Height / 2, this.diagramBox.Width, this.diagramBox.Height / 2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.checkBoxClearGraphs.Checked)
            {
                this.diagramBox.Refresh();
            }
            UpdateGraph();
        }

        private void UpdateGraph()
        {
            if (this.inputValid)
            {
                DrawCurve();
                FillValueTable();
                if (!this.dataGridValueTable.Visible)
                {
                    dataGridValueTable.Visible = true;
                }
            }
        }

        private void FillValueTable()
        {
            var calculator = new CurrentCalculator(this.unknownResistor);
            var table = new DataTable();
            var pixelToValueRelation = this.valueRange / this.diagramBox.Width;
            int stepRange = 50;
            table.Columns.Add("variabler Widerstand in Ohm");
            table.Columns.Add("Brücken- spannung in Volt");
            for (int i = 1; i <= 10; i++)
            {
                var foo = table.NewRow();
                foo["variabler Widerstand in Ohm"] = stepRange * pixelToValueRelation * i;
                foo["Brücken- spannung in Volt"] = calculator.CalculateCurrent(stepRange * pixelToValueRelation * i);
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
            var result = new PointF[this.diagramBox.Width];
            var builder = new PointBuilder(new CurrentCalculator(this.unknownResistor), this.diagramBox.Width, this.diagramBox.Height, this.valueRange);
            for (int i = 0; i < this.diagramBox.Width; i++)
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
                    if (Convert.ToSingle(textBox2.Text) <= 0)
                    {
                        throw new Exception("inputInvalid");
                    }
                    this.unknownResistor = Convert.ToSingle(textBox2.Text);
                    textBox2.BackColor = Color.White;
                    this.inputValid = true;
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
                this.inputValid = false;
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode.Equals(Keys.Enter))
                {
                    if (Convert.ToSingle(textBox1.Text) <= 0)
                    {
                        throw new Exception("inputInvalid");
                    }
                    this.valueRange = Convert.ToSingle(textBox1.Text);
                    this.diagramBox.Refresh();
                    textBox1.BackColor = Color.White;
                    this.inputValid = true;
                    SetDiagramText();
                    UpdateGraph();
                }
            }
            catch (Exception exception)
            {
                textBox1.BackColor = Color.Red;
                this.inputValid = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToSingle(textBox2.Text) <= 0)
                {
                    throw new Exception("inputInvalid");
                }
                this.unknownResistor = Convert.ToSingle(textBox2.Text);
                textBox2.BackColor = Color.White;
                this.inputValid = true;
            }
            catch (Exception exception)
            {
                textBox2.BackColor = Color.Red;
                this.inputValid = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToSingle(textBox1.Text) <= 0)
                {
                    throw new Exception("inputInvalid");
                }
                this.valueRange = Convert.ToSingle(textBox1.Text);
                this.inputValid = true;
                SetDiagramText();
                this.diagramBox.Refresh();
                UpdateGraph();
                textBox1.BackColor = Color.White;
            }
            catch (Exception exception)
            {
                textBox1.BackColor = Color.Red;
                this.inputValid = false;
            }
        }
    }

    public class PointBuilder
    {
        private readonly CurrentCalculator currentCalculator;
        private readonly int containerWidth;
        private readonly int containerHeight;
        private readonly float valueRange;

        public PointBuilder(CurrentCalculator currentCalculator, int containerWidth, int containerHeight, float valueRange)
        {
            this.currentCalculator = currentCalculator;
            this.containerWidth = containerWidth;
            this.containerHeight = containerHeight;
            this.valueRange = valueRange;
        }

        public PointF Build(int iteration)
        {
            var pixelToValueRelation = this.valueRange / this.containerWidth;
            return new PointF
            {
                X = iteration,
                Y = this.containerWidth - (containerHeight / 10 * this.currentCalculator.CalculateCurrent(pixelToValueRelation * iteration) + this.containerWidth / 2)
            };
        }
    }

    public class CurrentCalculator
    {
        private readonly float unknownResistor;

        public CurrentCalculator(float unknownResistor)
        {
            this.unknownResistor = unknownResistor;
        }

        public float CalculateCurrent(float variableResistor)
        {
            const float baseCurrent = 10;
            const float staticResistor = 10000;
            return baseCurrent * ((staticResistor * this.unknownResistor - staticResistor * variableResistor) /
                                  ((staticResistor + staticResistor) * (this.unknownResistor + variableResistor)));
        }
    }
}
