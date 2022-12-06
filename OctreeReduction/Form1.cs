using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace OctreeReduction
{
    public partial class Form1 : Form
    {
        private Bitmap imageBitmap;
        private Color[] imageColors;

        private int imageHeight;
        private int imageWidth;

        private Bitmap imageAlongBitmap;

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
            Reduce();
        }

        private void Reduce()
        {
            //build octrees
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

            int index;
            Color color2;
            for (int x = 0; x < imageWidth; x++)
                for (int y = 0; y < imageHeight; y++)
                {
                    index = OctreeAfter.GetPaletteIndex(imageColors[x + y * imageWidth]);
                    color2 = palette[index];
                    imageAfterBitmap.SetPixel(x, y, System.Drawing.Color.FromArgb(color2.Red, color2.Green, color2.Blue));
                }
            afterPicture.Image = imageAfterBitmap;


            var OctreeAlong = new Quantizer(5);

            imageAlongBitmap = new Bitmap(imageWidth,
                                          imageHeight);

            for (int x = 0; x < imageWidth; x++)
                for (int y = 0; y < imageHeight; y++)
                {
                    var color = imageBitmap.GetPixel(x, y);
                    //imageColors[x + y * imageWidth] = new Color(color.R, color.G, color.B);
                    OctreeAlong.AddColor(new Color(color.R, color.G, color.B));
                    if (OctreeAlong.GetLeaves().Count > colorsCount)
                    {
                        OctreeAlong.AdjustLeaves(16);
                    }
                }

            var paletteAlong = OctreeAlong.MakePalette(colorsCount);

            for (int x = 0; x < imageWidth; x++)
                for (int y = 0; y < imageHeight; y++)
                {
                    index = OctreeAlong.GetPaletteIndex(imageColors[x + y * imageWidth]);
                    color2 = paletteAlong[index];
                    imageAlongBitmap.SetPixel(x, y, System.Drawing.Color.FromArgb(color2.Red, color2.Green, color2.Blue));
                }

            alongPicture.Image = imageAlongBitmap;
        }

        private static Color IntToRGB(int color)
        {
            int R, G, B;
            R = (color & 0xff0000) >> 16;
            G = (color & 0xff00) >> 8;
            B = (color & 0xff);
            return new Color(R, G, B);

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
    }
}