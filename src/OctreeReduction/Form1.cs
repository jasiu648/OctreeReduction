
using OctreeReduction.Quantizers;

namespace OctreeReduction
{
    public partial class Form1 : Form
    {
        private Bitmap imageBitmap;
        private int imageHeight;
        private int imageWidth;
        private Bitmap imageAfterBitmap;
        private static readonly string ImagesDirectory = Path.Combine(AppContext.BaseDirectory, "assets", "images");
        private int colorsCount = 256;
        private IQuantizer quantizer;

        public Form1()
        {
            InitializeComponent();
            LoadImage(Path.Combine(ImagesDirectory, "nuke.jpg"));
            quantizer = new Quantizer();
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            dialog.InitialDirectory = Directory.Exists(ImagesDirectory)
                ? ImagesDirectory
                : Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            dialog.Title = "Please select an image file.";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadImage(dialog.FileName);
            }
        }

        private void LoadImage(string fileName)
        {
            using Image image = new Bitmap(fileName);
            imageBitmap?.Dispose();
            imageBitmap = new Bitmap(image.Width, image.Height);
            imageWidth = image.Width;
            imageHeight = image.Height;

            using Graphics graphics = Graphics.FromImage(imageBitmap);
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
            if (textBox1.Text.Length > 0)
            {
                if (int.TryParse(textBox1.Text, out int count) && count > 0 && count <= 1024)
                {
                    colorsCount = count;
                }
                else
                {
                    MessageBox.Show(
                        "Please provide a whole number between 1 and 1024.",
                        "Invalid color count",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            dialog.InitialDirectory = Directory.Exists(ImagesDirectory)
                ? ImagesDirectory
                : Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            dialog.Title = "Please select an image file.";

            if (dialog.ShowDialog() == DialogResult.OK && imageAfterBitmap is not null)
            {
                imageAfterBitmap.Save(dialog.FileName);
            }
        }
    }
}