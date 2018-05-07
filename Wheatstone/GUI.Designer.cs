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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            this.textBox1.Size = new System.Drawing.Size(43, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "10000";
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(586, 271);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(108, 20);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "4000";
            this.textBox2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(586, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "unknown resisitor in Ohm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "5V";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 567);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "-5V";
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 646);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private Label label1;
        private Label label2;
        private Label label3;
    }
}