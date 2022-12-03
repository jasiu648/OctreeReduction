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
            this.alongPicture = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.importButton = new System.Windows.Forms.Button();
            this.reduceButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.afterPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alongPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPicture
            // 
            this.mainPicture.Location = new System.Drawing.Point(48, 28);
            this.mainPicture.Name = "mainPicture";
            this.mainPicture.Size = new System.Drawing.Size(460, 290);
            this.mainPicture.TabIndex = 0;
            this.mainPicture.TabStop = false;
            this.mainPicture.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // afterPicture
            // 
            this.afterPicture.Location = new System.Drawing.Point(648, 28);
            this.afterPicture.Name = "afterPicture";
            this.afterPicture.Size = new System.Drawing.Size(460, 290);
            this.afterPicture.TabIndex = 1;
            this.afterPicture.TabStop = false;
            // 
            // alongPicture
            // 
            this.alongPicture.Location = new System.Drawing.Point(648, 355);
            this.alongPicture.Name = "alongPicture";
            this.alongPicture.Size = new System.Drawing.Size(460, 290);
            this.alongPicture.TabIndex = 2;
            this.alongPicture.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(778, 321);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Reduce after tree construction";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(778, 651);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Reduce along tree construction";
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(48, 329);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(226, 29);
            this.importButton.TabIndex = 6;
            this.importButton.Text = "Import file";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // reduceButton
            // 
            this.reduceButton.Location = new System.Drawing.Point(282, 329);
            this.reduceButton.Name = "reduceButton";
            this.reduceButton.Size = new System.Drawing.Size(226, 29);
            this.reduceButton.TabIndex = 7;
            this.reduceButton.Text = "Reduce";
            this.reduceButton.UseVisualStyleBackColor = true;
            this.reduceButton.Click += new System.EventHandler(this.reduceButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(397, 364);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(111, 27);
            this.textBox1.TabIndex = 8;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 367);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Color count:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 680);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.reduceButton);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.alongPicture);
            this.Controls.Add(this.afterPicture);
            this.Controls.Add(this.mainPicture);
            this.Name = "Form1";
            this.Text = "Octree Color Reduction";
            ((System.ComponentModel.ISupportInitialize)(this.mainPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.afterPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alongPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox mainPicture;
        private PictureBox afterPicture;
        private PictureBox alongPicture;
        private Label label1;
        private Label label2;
        private Button importButton;
        private Button reduceButton;
        private TextBox textBox1;
        private Label label3;
    }
}