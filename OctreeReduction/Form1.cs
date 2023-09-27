
using System.Drawing.Imaging;

namespace OctreeReduction
{
    public partial class Form1 : Form
    {
        private Bitmap imageBitmap;
        

        private int imageHeight;
        private int imageWidth;

        private Bitmap imageAfterBitmap;

        private readonly string DEFAULT_IMAGE_PATH = "..\\..\\..\\images\\nuke.jpg";

        private int colorsCount = 256;

        private IQuantizer quantizer;

        public Form1()
        {
            
            InitializeComponent();
            LoadImage(DEFAULT_IMAGE_PATH);
            

            quantizer = new Quantizer();
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            dialog.InitialDirectory = Path.GetFullPath("..\\..\\..\\images");
            dialog.Title = "Please select an image file.";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadImage(dialog.FileName);
            }
        }

        private void LoadImage(string fileName)
        {
            Image image = new Bitmap(fileName);

            imageBitmap = new Bitmap(image.Width,image.Height);

            imageWidth = image.Width;
            imageHeight = image.Height;

            Graphics graphics = Graphics.FromImage(imageBitmap);
            graphics.DrawImage(image, 0, 0, imageWidth, imageHeight);

            mainPicture.Image = imageBitmap;
        }

        private void reduceButton_Click(object sender, EventArgs e)
        {
            QuantizeBitmap();
        }

        private void QuantizeBitmap()
        {
            quantizer = new Quantizer(8);

            imageAfterBitmap = quantizer.Quantize(imageBitmap, imageWidth, imageHeight, colorsCount);
            afterPicture.Image = imageAfterBitmap;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text.Length > 0)
            {
                if (int.TryParse(textBox1.Text, out int count))
                    colorsCount = count;

                else
                    MessageBox.Show("Please provide valid number of colors");
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            dialog.InitialDirectory = Path.GetFullPath("..\\..\\..\\images");
            dialog.Title = "Please select an image file.";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imageAfterBitmap.Save(dialog.FileName);
            }
        }
    }
}