using System;
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
            DrawLine(100);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.diagramBox.Invalidate();
        }
    }
}
