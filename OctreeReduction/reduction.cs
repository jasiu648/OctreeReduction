//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Drawing.Imaging;
//using System.Linq;
//using static System.Net.Mime.MediaTypeNames;

//namespace OctreeColorReduction
//{
//    // Octree node class
//    public class OctreeNode
//    {
//        // The 8 child nodes of this node
//        public OctreeNode[] Children { get; set; }

//        public OctreeNode Parent { get; set; }

//        // The color count at this node
//        public int ColorCount { get; set; }

//        // The average color of all colors stored at this node and its children
//        public Color AverageColor { get; set; }

//        public OctreeNode()
//        {
//            Children = new OctreeNode[8];
//        }
//    }

//    // Octree class
//    public class Octree
//    {
//        // The root node of the octree
//        private OctreeNode root;

//        // The maximum number of colors that the octree can store
//        private int maxColors;

//        // The current number of colors stored in the octree
//        private int colorCount;

//        public Octree(int maxColors)
//        {
//            this.maxColors = maxColors;
//            root = new OctreeNode();
//        }

//        // Adds a color to the octree
//        public void AddColor(Color color)
//        {
//            // Start at the root of the tree
//            OctreeNode current = root;

//            // Loop through each level of the tree
//            for (int level = 0; level < 8; level++)
//            {
//                // Calculate the index of the child node at this level
//                // based on the color's RGB values
//                int index = GetOctreeIndex(color, level);

//                // If the child node doesn't exist, create it
//                if (current.Children[index] == null)
//                {
//                    current.Children[index] = new OctreeNode() { Parent = current };
//                }

//                // Move to the child node
//                current = current.Children[index];
//            }

//            // Increment the color count at this node
//            current.ColorCount++;

//            // Update the average color at this node
//            current.AverageColor = CalculateAverageColor(current.AverageColor, color, current.ColorCount);

//            // Increment the total number of colors stored in the tree
//            colorCount++;

//            // If the tree is full, reduce it
//            if (colorCount > maxColors)
//            {
//                Reduce();
//            }
//        }

//        // Reduces the octree to the maximum number of colors
//        public void Reduce()
//        {
//            // Traverse the tree and find all leaf nodes
//            var leaves = GetLeaves();

//            // Sort the leaf nodes by color count
//            Array.Sort(leaves, (x, y) => y.ColorCount - x.ColorCount);

//            // Trim the leaf nodes until the tree contains the maximum number of colors
//            while (colorCount > maxColors)
//            {
//                // Remove the leaf with the largest color count
//                OctreeNode largest = leaves[0];
//                largest.ColorCount = 0;
//                colorCount--;

//                // Update the average color of the parent nodes
//                OctreeNode current = largest;
//                while (current != root)
//                {
//                    current = current.Parent;
//                    current.AverageColor = CalculateAverageColor(current.AverageColor, largest.AverageColor, -largest.ColorCount);
//                }
//                // Re-sort the leaf nodes
//                Array.Sort(leaves, (x, y) => y.ColorCount - x.ColorCount);
//            }
//        }

//        // Gets the index of the child node at the specified level
//        private int GetOctreeIndex(Color color, int level)
//        {
//            // Calculate the mask for this level
//            int mask = 255 << (8 - (level + 1) * 3);

//            // Use the mask to get the relevant RGB values
//            int r = (color.R & mask) >> (8 - (level + 1) * 3);
//            int g = (color.G & mask) >> (8 - (level + 1) * 3);
//            int b = (color.B & mask) >> (8 - (level + 1) * 3);

//            // Return the index of the child node
//            return (r << 2) | (g << 1) | b;
//        }

//        // Calculates the average color of two colors
//        private Color CalculateAverageColor(Color color1, Color color2, int count)
//        {
//            int r = (color1.R * count + color2.R) / (count + 1);
//            int g = (color1.G * count + color2.G) / (count + 1);
//            int b = (color1.B * count + color2.B) / (count + 1);

//            return Color.FromArgb(r, g, b);
//        }

//        // Gets an array of all leaf nodes in the tree
//        private OctreeNode[] GetLeaves()
//        {
//            var leaves = new List<OctreeNode>();
//            GetLeaves(root, leaves);
//            return leaves.ToArray();
//        }

//        // Recursively gets the leaf nodes of the tree
//        private void GetLeaves(OctreeNode node, List<OctreeNode> leaves)
//        {
//            if (node.Children.All(x => x == null))
//            {
//                // This node is a leaf node
//                leaves.Add(node);
//            }
//            else
//            {
//                // Recursively get the leaf nodes of the child nodes
//                foreach (OctreeNode child in node.Children)
//                {
//                    if (child != null)
//                    {
//                        GetLeaves(child, leaves);
//                    }
//                }
//            }
//        }

//        // Gets the palette of colors in the octree
//        public Color[] GetPalette()
//        {
//            var palette = new List<Color>();
//            GetPalette(root, palette);
//            return palette.ToArray();
//        }

//        // Recursively gets the palette of colors in the tree
//        private void GetPalette(OctreeNode node, List<Color> palette)
//        {
//            if (node.Children.All(x => x == null))
//            {
//                // This node is a leaf node, so add its average color to the palette
//                palette.Add(node.AverageColor);
//            }
//            else
//            {
//                // Recursively get the palette of the child nodes
//                foreach (OctreeNode child in node.Children)
//                {
//                    if (child != null)
//                    {
//                        GetPalette(child, palette);
//                    }
//                }
//            }
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // Load the image
//            Bitmap image = (Bitmap)System.Drawing.Image.FromFile("..\\..\\..\\images\\nuke.jpg");

//            // Create a new octree with a maximum of 256 colors
//            Octree octree = new Octree(256);

//            // Loop through each pixel in the image
//            for (int x = 0; x < image.Width; x++)
//            {
//                for (int y = 0; y < image.Height; y++)
//                {
//                    // Get the color of the pixel
//                    Color color = image.GetPixel(x, y);

//                    // Add the color to the octree
//                    octree.AddColor(color);
//                }
//            }

//            // Reduce the octree to the maximum number of colors
//            octree.Reduce();

//            // Get the palette of colors from the octree
//            Color[] palette = octree.GetPalette();

//            // Create a new bitmap with the reduced color palette
//            Bitmap reducedImage = new Bitmap(image.Width, image.Height, PixelFormat.Format8bppIndexed);

//            // Set the color palette of the bitmap to the reduced palette
//            //reducedImage.Palette = palette;

//            // Loop through each pixel in the image
//            for (int x = 0; x < image.Width; x++)
//            {
//                for (int y = 0; y < image.Height; y++)
//                {
//                    // Get the color of the pixel
//                    Color color = image.GetPixel(x, y);

//                    // Find the closest matching color in the palette
//                    int index = GetClosestColorIndex(color, palette);

//                    // Set the pixel's color in the reduced image
//                    reducedImage.SetPixel(x, y, palette[index]);
//                }
//            }

//            // Save the reduced image
//            reducedImage.Save("C:\\Path\\To\\ReducedImage.png", ImageFormat.Png);
//        }

//        // Gets the index of the color in the palette that is closest to the specified color
//        private static int GetClosestColorIndex(Color color, Color[] palette)
//        {
//            int index = 0;
//            int minDistance = int.MaxValue;

//            for (int i = 0; i < palette.Length; i++)
//            {
//                // Calculate the distance between the two colors
//                int distance = GetColorDistance(color, palette[i]);

//                // If this color is closer than the previous closest color, update the index
//                if (distance < minDistance)
//                {
//                    index = i;
//                    minDistance = distance;
//                }
//            }

//            return index;
//        }

//        // Calculates the distance between two colors
//        private static int GetColorDistance(Color color1, Color color2)
//        {
//            int r = color1.R - color2.R;
//            int g = color1.G - color2.G;
//            int b = color1.B - color2.B;

//            return r * r + g * g + b * b;
//        }
//    }
//}
