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
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.afterPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPicture
            // 
            this.mainPicture.Location = new System.Drawing.Point(41, 61);
            this.mainPicture.Name = "mainPicture";
            this.mainPicture.Size = new System.Drawing.Size(541, 399);
            this.mainPicture.TabIndex = 0;
            this.mainPicture.TabStop = false;
            this.mainPicture.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // afterPicture
            // 
            this.afterPicture.Location = new System.Drawing.Point(666, 61);
            this.afterPicture.Name = "afterPicture";
            this.afterPicture.Size = new System.Drawing.Size(577, 399);
            this.afterPicture.TabIndex = 1;
            this.afterPicture.TabStop = false;
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(96, 466);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(226, 29);
            this.importButton.TabIndex = 6;
            this.importButton.Text = "Import file";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // reduceButton
            // 
            this.reduceButton.Location = new System.Drawing.Point(344, 466);
            this.reduceButton.Name = "reduceButton";
            this.reduceButton.Size = new System.Drawing.Size(226, 29);
            this.reduceButton.TabIndex = 7;
            this.reduceButton.Text = "Reduce";
            this.reduceButton.UseVisualStyleBackColor = true;
            this.reduceButton.Click += new System.EventHandler(this.reduceButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(439, 501);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(111, 27);
            this.textBox1.TabIndex = 8;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(344, 504);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Color count:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(864, 466);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(226, 29);
            this.button1.TabIndex = 10;
            this.button1.Text = "Save file";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 549);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.reduceButton);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.afterPicture);
            this.Controls.Add(this.mainPicture);
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
        private Button button1;
    }
}