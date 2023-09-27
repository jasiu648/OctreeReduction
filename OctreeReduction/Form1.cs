
namespace OctreeReduction
{
    public partial class Form1 : Form
    {
        private Bitmap imageBitmap;
        private Color[] imageColors;

        private int imageHeight;
        private int imageWidth;

        private Bitmap imageAfterBitmap;

        private readonly string DEFAULT_IMAGE_PATH = "..\\..\\..\\images\\nuke.jpg";

        private int colorsCount = 256;


        public Form1()
        {
            imageHeight = 300;
            imageWidth = 460;
            InitializeComponent();
            LoadImage(DEFAULT_IMAGE_PATH);
            imageColors = new Color[imageHeight * imageWidth];
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

            imageBitmap = new Bitmap(imageWidth,
                                          imageHeight);

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
            var OctreeAfter = new Quantizer(8);

            for (int x = 0; x < imageWidth; x++)
                for (int y = 0; y < imageHeight; y++)
                {
                    var color = imageBitmap.GetPixel(x, y);
                    imageColors[x + y * imageWidth] = new Color(color.R, color.G, color.B);
                    OctreeAfter.AddColor(new Color(color.R,color.G,color.B));
                }
;
            var palette = OctreeAfter.MakePalette(colorsCount);

            imageAfterBitmap = new Bitmap(imageWidth,
                                          imageHeight);

            
            for (int x = 0; x < imageWidth; x++)
                for (int y = 0; y < imageHeight; y++)
                {
                    var index = OctreeAfter.GetPaletteIndex(imageColors[x + y * imageWidth]);
                    var color = palette[index];
                    imageAfterBitmap.SetPixel(x, y, System.Drawing.Color.FromArgb(color.Red, color.Green, color.Blue));
                }
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

        }
    }
}