using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctreeReduction
{
    public class Quantizer
    {
        public static readonly int MAX_DEPTH = 8;
        public OctreeNode Root;
        public Dictionary<int, List<OctreeNode>> Levels;
        public Quantizer() 
        {
            Root = new OctreeNode(0, Root);
            Levels = new Dictionary<int, List<OctreeNode>>();

            for(int i = 0; i < MAX_DEPTH; i++)
            {
                Levels.Add(i, new List<OctreeNode>());
            }
        }

        public List<OctreeNode> GetLeaves()
        {
            return Root.GetLeaves(); 
        }

        public void AddLevelNode(int level, OctreeNode node)
        {
            Levels[level].Add(node);
        }

        public void AddColor(Color color)
        {
            Root.AddColor(color, 0, Root);
        }

        public List<Color> MakePalette(int colorCount) 
        {
            List<Color> Palette = new List<Color>();
            int paletteIndex = 0;
            int leafCount = Root.GetLeaves().Count;

            for(int i = MAX_DEPTH - 1; i >= 0; i--)
            {
                if (Levels[i] is not null)
                {
                    foreach(var node in Levels[i])
                    {
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
    }
}
