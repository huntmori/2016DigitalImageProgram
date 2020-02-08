namespace _2016DigitalImageProcessing
{
    partial class TriangleInput
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
            this.Point1_X = new System.Windows.Forms.TextBox();
            this.Point1_Y = new System.Windows.Forms.TextBox();
            this.Point2_Y = new System.Windows.Forms.TextBox();
            this.Point2_X = new System.Windows.Forms.TextBox();
            this.Point3_Y = new System.Windows.Forms.TextBox();
            this.Point3_X = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Point1_X
            // 
            this.Point1_X.Location = new System.Drawing.Point(27, 24);
            this.Point1_X.Name = "Point1_X";
            this.Point1_X.Size = new System.Drawing.Size(100, 21);
            this.Point1_X.TabIndex = 0;
            this.Point1_X.TextChanged += new System.EventHandler(this.Point1_X_TextChanged);
            // 
            // Point1_Y
            // 
            this.Point1_Y.Location = new System.Drawing.Point(27, 51);
            this.Point1_Y.Name = "Point1_Y";
            this.Point1_Y.Size = new System.Drawing.Size(100, 21);
            this.Point1_Y.TabIndex = 1;
            this.Point1_Y.TextChanged += new System.EventHandler(this.Point1_Y_TextChanged);
            // 
            // Point2_Y
            // 
            this.Point2_Y.Location = new System.Drawing.Point(133, 51);
            this.Point2_Y.Name = "Point2_Y";
            this.Point2_Y.Size = new System.Drawing.Size(100, 21);
            this.Point2_Y.TabIndex = 3;
            this.Point2_Y.TextChanged += new System.EventHandler(this.Point2_Y_TextChanged);
            // 
            // Point2_X
            // 
            this.Point2_X.Location = new System.Drawing.Point(133, 24);
            this.Point2_X.Name = "Point2_X";
            this.Point2_X.Size = new System.Drawing.Size(100, 21);
            this.Point2_X.TabIndex = 2;
            this.Point2_X.TextChanged += new System.EventHandler(this.Point2_X_TextChanged);
            // 
            // Point3_Y
            // 
            this.Point3_Y.Location = new System.Drawing.Point(239, 51);
            this.Point3_Y.Name = "Point3_Y";
            this.Point3_Y.Size = new System.Drawing.Size(100, 21);
            this.Point3_Y.TabIndex = 5;
            this.Point3_Y.TextChanged += new System.EventHandler(this.Point3_Y_TextChanged);
            // 
            // Point3_X
            // 
            this.Point3_X.Location = new System.Drawing.Point(239, 24);
            this.Point3_X.Name = "Point3_X";
            this.Point3_X.Size = new System.Drawing.Size(100, 21);
            this.Point3_X.TabIndex = 4;
            this.Point3_X.TextChanged += new System.EventHandler(this.Point3_X_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "x";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Point1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Point2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(237, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "Point3";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(183, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(264, 107);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // TriangleInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 139);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Point3_Y);
            this.Controls.Add(this.Point3_X);
            this.Controls.Add(this.Point2_Y);
            this.Controls.Add(this.Point2_X);
            this.Controls.Add(this.Point1_Y);
            this.Controls.Add(this.Point1_X);
            this.Name = "TriangleInput";
            this.Text = "TriangleInput";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Point1_X;
        private System.Windows.Forms.TextBox Point1_Y;
        private System.Windows.Forms.TextBox Point2_Y;
        private System.Windows.Forms.TextBox Point2_X;
        private System.Windows.Forms.TextBox Point3_Y;
        private System.Windows.Forms.TextBox Point3_X;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}