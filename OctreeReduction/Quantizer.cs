using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctreeReduction
{
    public class Quantizer : IQuantizer
    {
        public readonly int MAX_DEPTH = 8;
        public OctreeNode Root;
        public List<OctreeNode>[] Levels;
        
        public Quantizer(int maxDepth = 8) 
        {
            MAX_DEPTH = maxDepth;
            Levels = new List<OctreeNode>[MAX_DEPTH];

            for (int i = 0; i < MAX_DEPTH - 1; i++)
                Levels[i] = new List<OctreeNode>();

            Root = new OctreeNode(0, this);
        }

        public List<OctreeNode> GetLeaves()
        {
            return Root.GetLeaves(); 
        }

        public void AddColor(Color color)
        {
            Root.AddColor(color, 0, this);
        }

        public void AdjustLeaves(int colorCount)
        {
            int leafCount = GetLeaves().Count;
            int paletteIndex = 0;

            for (int i = MAX_DEPTH - 1; i >= 0; i--)
            {
                if (Levels[i] is not null)
                {
                    foreach (var node in Levels[i])
                    {
                        if (node is null) continue;

                        leafCount -= node.RemoveLeaves();
                        if (leafCount <= colorCount)
                            break;
                    }
                    if (leafCount <= colorCount)
                        break;

                    Levels[i] = new List<OctreeNode>();
                }
            }
            foreach (var node in Root.GetLeaves())
            {

                node.palletteIndex = paletteIndex;
                paletteIndex++;

            }
        }
        public List<Color> MakePalette(int colorCount) 
        {
            List<Color> Palette = new List<Color>();
            int paletteIndex = 0;
            int leafCount = GetLeaves().Count;
            
            for(int i = MAX_DEPTH - 1; i >= 0; i--)
            {
                if (Levels[i] is not null)
                {
                    foreach(var node in Levels[i])
                    {
                        if(node is null) continue;

                        leafCount -= node.RemoveLeaves();
                        if (leafCount <= colorCount)
                            break;
                    }
                    if (leafCount <= colorCount)
                        break;

                    Levels[i] = new List<OctreeNode>();
                }
            }

            foreach(var node in Root.GetLeaves())
            {
                if (paletteIndex >= colorCount)
                    break;
                if (node.IsLeaf())
                    Palette.Add(node.GetColor());
                node.palletteIndex = paletteIndex;
                paletteIndex++;

            }
            return Palette;
        }

        public int GetPaletteIndex(Color color)
        {
            return Root.GetPalletteIndex(color, 0);
        }

        public Bitmap Quantize(Bitmap imageBitmap, int imageWidth, int imageHeight, int colorsCount)
        {
            var imageColors = new Color[imageHeight * imageWidth];
            for (int x = 0; x < imageWidth; x++)
                for (int y = 0; y < imageHeight; y++)
                {
                    var color = imageBitmap.GetPixel(x, y);
                    imageColors[x + y * imageWidth] = new Color(color.R, color.G, color.B);
                    AddColor(new Color(color.R, color.G, color.B));
                }
;
            var palette = MakePalette(colorsCount);

            var imageAfterBitmap = new Bitmap(imageWidth, imageHeight);


            for (int x = 0; x < imageWidth; x++)
                for (int y = 0; y < imageHeight; y++)
                {
                    var index = GetPaletteIndex(imageColors[x + y * imageWidth]);
                    var color = palette[index];
                    imageAfterBitmap.SetPixel(x, y, System.Drawing.Color.FromArgb(color.Red, color.Green, color.Blue));
                }

            return imageAfterBitmap;
        }
    }
}
