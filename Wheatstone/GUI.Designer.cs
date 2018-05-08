using System.Drawing;
using System.Windows.Forms;

namespace Wheatstone
{
    partial class GUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.diagramBox = new System.Windows.Forms.PictureBox();
            this.buttonToDrawGraph = new System.Windows.Forms.Button();
            this.buttonToClearImage = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.unknownResistorInputLabel = new System.Windows.Forms.Label();
            this.voltageUpperBorderLabel = new System.Windows.Forms.Label();
            this.voltageLowerBorderLabel = new System.Windows.Forms.Label();
            this.voltageZeroLabel = new System.Windows.Forms.Label();
            this.resistorZeroLabel = new System.Windows.Forms.Label();
            this.resistorFirstLabel = new System.Windows.Forms.Label();
            this.resistorSecondLabel = new System.Windows.Forms.Label();
            this.ResistorThirdLabel = new System.Windows.Forms.Label();
            this.resistorFourthLabel = new System.Windows.Forms.Label();
            this.resistorUpperLabel = new System.Windows.Forms.Label();
            this.checkBoxClearGraphs = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.diagramBox)).BeginInit();
            this.SuspendLayout();
            // 
            // diagramBox
            // 
            this.diagramBox.BackColor = System.Drawing.Color.White;
            this.diagramBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.diagramBox.Location = new System.Drawing.Point(80, 80);
            this.diagramBox.Name = "diagramBox";
            this.diagramBox.Size = new System.Drawing.Size(500, 500);
            this.diagramBox.TabIndex = 0;
            this.diagramBox.TabStop = false;
            this.diagramBox.Paint += new System.Windows.Forms.PaintEventHandler(this.diagramBox_Paint);
            // 
            // buttonToDrawGraph
            // 
            this.buttonToDrawGraph.Location = new System.Drawing.Point(586, 80);
            this.buttonToDrawGraph.Name = "buttonToDrawGraph";
            this.buttonToDrawGraph.Size = new System.Drawing.Size(108, 23);
            this.buttonToDrawGraph.TabIndex = 2;
            this.buttonToDrawGraph.Text = "Draw graph";
            this.buttonToDrawGraph.UseVisualStyleBackColor = true;
            this.buttonToDrawGraph.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonToClearImage
            // 
            this.buttonToClearImage.Location = new System.Drawing.Point(586, 166);
            this.buttonToClearImage.Name = "buttonToClearImage";
            this.buttonToClearImage.Size = new System.Drawing.Size(108, 23);
            this.buttonToClearImage.TabIndex = 3;
            this.buttonToClearImage.Text = "Clear diagram";
            this.buttonToClearImage.UseVisualStyleBackColor = true;
            this.buttonToClearImage.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(561, 586);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(71, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "10000";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(586, 271);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(108, 20);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "4000";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyUp);
            // 
            // unknownResistorInputLabel
            // 
            this.unknownResistorInputLabel.AutoSize = true;
            this.unknownResistorInputLabel.Location = new System.Drawing.Point(586, 255);
            this.unknownResistorInputLabel.Name = "unknownResistorInputLabel";
            this.unknownResistorInputLabel.Size = new System.Drawing.Size(123, 13);
            this.unknownResistorInputLabel.TabIndex = 6;
            this.unknownResistorInputLabel.Text = "unknown resistor in Ohm";
            // 
            // voltageUpperBorderLabel
            // 
            this.voltageUpperBorderLabel.AutoSize = true;
            this.voltageUpperBorderLabel.Location = new System.Drawing.Point(39, 80);
            this.voltageUpperBorderLabel.Name = "voltageUpperBorderLabel";
            this.voltageUpperBorderLabel.Size = new System.Drawing.Size(20, 13);
            this.voltageUpperBorderLabel.TabIndex = 7;
            this.voltageUpperBorderLabel.Text = "5V";
            // 
            // voltageLowerBorderLabel
            // 
            this.voltageLowerBorderLabel.AutoSize = true;
            this.voltageLowerBorderLabel.Location = new System.Drawing.Point(39, 567);
            this.voltageLowerBorderLabel.Name = "voltageLowerBorderLabel";
            this.voltageLowerBorderLabel.Size = new System.Drawing.Size(23, 13);
            this.voltageLowerBorderLabel.TabIndex = 8;
            this.voltageLowerBorderLabel.Text = "-5V";
            // 
            // voltageZeroLabel
            // 
            this.voltageZeroLabel.AutoSize = true;
            this.voltageZeroLabel.Location = new System.Drawing.Point(42, 325);
            this.voltageZeroLabel.Name = "voltageZeroLabel";
            this.voltageZeroLabel.Size = new System.Drawing.Size(20, 13);
            this.voltageZeroLabel.TabIndex = 9;
            this.voltageZeroLabel.Text = "0V";
            // 
            // resistorZeroLabel
            // 
            this.resistorZeroLabel.AutoSize = true;
            this.resistorZeroLabel.Location = new System.Drawing.Point(77, 589);
            this.resistorZeroLabel.Name = "resistorZeroLabel";
            this.resistorZeroLabel.Size = new System.Drawing.Size(38, 13);
            this.resistorZeroLabel.TabIndex = 10;
            this.resistorZeroLabel.Text = "0 Ohm";
            // 
            // resistorFirstLabel
            // 
            this.resistorFirstLabel.AutoSize = true;
            this.resistorFirstLabel.Location = new System.Drawing.Point(150, 589);
            this.resistorFirstLabel.Name = "resistorFirstLabel";
            this.resistorFirstLabel.Size = new System.Drawing.Size(0, 13);
            this.resistorFirstLabel.TabIndex = 11;
            // 
            // resistorSecondLabel
            // 
            this.resistorSecondLabel.AutoSize = true;
            this.resistorSecondLabel.Location = new System.Drawing.Point(250, 589);
            this.resistorSecondLabel.Name = "resistorSecondLabel";
            this.resistorSecondLabel.Size = new System.Drawing.Size(0, 13);
            this.resistorSecondLabel.TabIndex = 12;
            // 
            // ResistorThirdLabel
            // 
            this.ResistorThirdLabel.AutoSize = true;
            this.ResistorThirdLabel.Location = new System.Drawing.Point(350, 589);
            this.ResistorThirdLabel.Name = "ResistorThirdLabel";
            this.ResistorThirdLabel.Size = new System.Drawing.Size(0, 13);
            this.ResistorThirdLabel.TabIndex = 13;
            // 
            // resistorFourthLabel
            // 
            this.resistorFourthLabel.AutoSize = true;
            this.resistorFourthLabel.Location = new System.Drawing.Point(450, 589);
            this.resistorFourthLabel.Name = "resistorFourthLabel";
            this.resistorFourthLabel.Size = new System.Drawing.Size(0, 13);
            this.resistorFourthLabel.TabIndex = 14;
            // 
            // resistorUpperLabel
            // 
            this.resistorUpperLabel.AutoSize = true;
            this.resistorUpperLabel.Location = new System.Drawing.Point(638, 589);
            this.resistorUpperLabel.Name = "resistorUpperLabel";
            this.resistorUpperLabel.Size = new System.Drawing.Size(29, 13);
            this.resistorUpperLabel.TabIndex = 15;
            this.resistorUpperLabel.Text = "Ohm";
            // 
            // checkBoxClearGraphs
            // 
            this.checkBoxClearGraphs.AutoSize = true;
            this.checkBoxClearGraphs.Location = new System.Drawing.Point(586, 297);
            this.checkBoxClearGraphs.Name = "checkBoxClearGraphs";
            this.checkBoxClearGraphs.Size = new System.Drawing.Size(101, 17);
            this.checkBoxClearGraphs.TabIndex = 16;
            this.checkBoxClearGraphs.Text = "clear old graphs";
            this.checkBoxClearGraphs.UseVisualStyleBackColor = true;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 646);
            this.Controls.Add(this.checkBoxClearGraphs);
            this.Controls.Add(this.resistorUpperLabel);
            this.Controls.Add(this.resistorFourthLabel);
            this.Controls.Add(this.ResistorThirdLabel);
            this.Controls.Add(this.resistorSecondLabel);
            this.Controls.Add(this.resistorFirstLabel);
            this.Controls.Add(this.resistorZeroLabel);
            this.Controls.Add(this.voltageZeroLabel);
            this.Controls.Add(this.voltageLowerBorderLabel);
            this.Controls.Add(this.voltageUpperBorderLabel);
            this.Controls.Add(this.unknownResistorInputLabel);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonToClearImage);
            this.Controls.Add(this.buttonToDrawGraph);
            this.Controls.Add(this.diagramBox);
            this.Name = "GUI";
            this.Text = "GUI";
            ((System.ComponentModel.ISupportInitialize)(this.diagramBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox diagramBox;
        private System.Windows.Forms.Button buttonToDrawGraph;
        private System.Windows.Forms.Button buttonToClearImage;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label unknownResistorInputLabel;
        private Label voltageUpperBorderLabel;
        private Label voltageLowerBorderLabel;
        private Label voltageZeroLabel;
        private Label resistorZeroLabel;
        private Label resistorFirstLabel;
        private Label resistorSecondLabel;
        private Label ResistorThirdLabel;
        private Label resistorFourthLabel;
        private Label resistorUpperLabel;
        private CheckBox checkBoxClearGraphs;
    }
}