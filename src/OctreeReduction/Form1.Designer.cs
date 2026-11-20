namespace OctreeReduction
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainPicture = new System.Windows.Forms.PictureBox();
            this.afterPicture = new System.Windows.Forms.PictureBox();
            this.importButton = new System.Windows.Forms.Button();
            this.reduceButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.afterPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPicture
            // 
            this.mainPicture.Location = new System.Drawing.Point(87, 125);
            this.mainPicture.Margin = new System.Windows.Forms.Padding(6);
            this.mainPicture.Name = "mainPicture";
            this.mainPicture.Size = new System.Drawing.Size(1150, 818);
            this.mainPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mainPicture.TabIndex = 0;
            this.mainPicture.TabStop = false;
            // 
            // afterPicture
            // 
            this.afterPicture.Location = new System.Drawing.Point(1415, 125);
            this.afterPicture.Margin = new System.Windows.Forms.Padding(6);
            this.afterPicture.Name = "afterPicture";
            this.afterPicture.Size = new System.Drawing.Size(1226, 818);
            this.afterPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.afterPicture.TabIndex = 1;
            this.afterPicture.TabStop = false;
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(204, 955);
            this.importButton.Margin = new System.Windows.Forms.Padding(6);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(480, 59);
            this.importButton.TabIndex = 6;
            this.importButton.Text = "Import file";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // reduceButton
            // 
            this.reduceButton.Location = new System.Drawing.Point(731, 955);
            this.reduceButton.Margin = new System.Windows.Forms.Padding(6);
            this.reduceButton.Name = "reduceButton";
            this.reduceButton.Size = new System.Drawing.Size(480, 59);
            this.reduceButton.TabIndex = 7;
            this.reduceButton.Text = "Reduce";
            this.reduceButton.UseVisualStyleBackColor = true;
            this.reduceButton.Click += new System.EventHandler(this.reduceButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(933, 1027);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(231, 47);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "256";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(731, 1033);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 41);
            this.label3.TabIndex = 9;
            this.label3.Text = "Color count:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(1415, 967);
            this.saveButton.Margin = new System.Windows.Forms.Padding(6);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(480, 59);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Save file";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2707, 1125);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.reduceButton);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.afterPicture);
            this.Controls.Add(this.mainPicture);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Octree Color Reduction";
            ((System.ComponentModel.ISupportInitialize)(this.mainPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.afterPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox mainPicture;
        private PictureBox afterPicture;
        private Button importButton;
        private Button reduceButton;
        private TextBox textBox1;
        private Label label3;
        private Button saveButton;
    }
}