using System.Runtime.InteropServices;

namespace OctreeReduction
{
    public partial class Form1 : Form
    {
        private Bitmap imageBitmap;
        private Int32[] imageBits;
        private GCHandle imageBitsHandle;

        private int imageHeight;
        private int imageWidth;

        private Int32[] imageBitsTemp;

        private Bitmap imageAlongBitmap;
        private Int32[] imageAlongBits;
        private GCHandle imageAlongBitsHandle;

        private Bitmap imageAfterBitmap;
        private Int32[] imageAfterBits;
        private GCHandle imageAfterBitsHandle;

        private readonly string DEFAULT_IMAGE_PATH = "..\\..\\..\\images\\nuke.jpg";

        private int colorsCount = 16;

        public Form1()
        {
            imageHeight = 290;
            imageWidth = 460;
            InitializeComponent();
            LoadImage(DEFAULT_IMAGE_PATH);

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

            imageBits = new Int32[imageHeight * imageWidth];
            imageBitsHandle = GCHandle.Alloc(imageBits, GCHandleType.Pinned);
            imageBitmap = new Bitmap(imageWidth,
                                          imageHeight,
                                          imageWidth * 4,
                                          System.Drawing.Imaging.PixelFormat.Format32bppPArgb,
                                          imageBitsHandle.AddrOfPinnedObject());

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
            //build octree
            var Octree = new Quantizer();

            for (int x = 0; x < imageWidth; x++)
                for (int y = 0; y < imageHeight; y++)
                {
                    var color = GetObjectColorAtPos(x, y);
                    Octree.AddColor(color);
                }

            var palette = Octree.MakePalette(256);

            imageAfterBits = new Int32[imageHeight * imageWidth];

        }

        private Color GetObjectColorAtPos(int x, int y)
        {

            return IntToRGB(imageBits[x + y * imageWidth]);

        }

        private static Color IntToRGB(int color)
        {
            int R, G, B;
            R = (color & 0xff0000) >> 16;
            G = (color & 0xff00) >> 8;
            B = (color & 0xff);
            return new Color(R, G, B, 0);

        }

        private static int RGBToInt(Color color)
        {
            return (255 << 24) + (color.Red << 16) + (color.Green << 8) + color.Blue;
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