using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace OctreeReduction
{
    public class OctreeNode
    {
        OctreeNode[] childrenNodes;
        public Color color;
        int pixelCount;
        public int palletteIndex;

        public OctreeNode(int level, Quantizer parent)
        {
            this.color = new Color(0, 0, 0, 0);
            this.pixelCount = 0;
            this.palletteIndex = 0;
            this.childrenNodes = new OctreeNode[8];

            if (level < parent.MAX_DEPTH - 1)
                parent.AddLevelNode(level, this);
        }

        public bool IsLeaf() => pixelCount > 0;
        public List<OctreeNode> GetLeaves() {
            List<OctreeNode> Leaves = new List<OctreeNode>();
            foreach(var child in childrenNodes)
            {
                if(child is null) continue;
                if (child.IsLeaf())
                {
                    Leaves.Add(child);
                }
                else
                {
                    Leaves.AddRange(child.GetLeaves());
                }
            }
            return Leaves;
        }

        public int GetPixelCount()
        {
            int sum = pixelCount;

            foreach(var child in childrenNodes)
            {
                sum += child.pixelCount;
            }

            return sum;
        }

        public void AddColor(Color color, int level, Quantizer parent)
        {
            if(level >= parent.MAX_DEPTH)
            {
                this.color.Red += color.Red;
                this.color.Blue += color.Blue;
                this.color.Green += color.Green;
                pixelCount++;
                return;
            }

            int index = GetColorIndexForLevel(color, level);
            if (childrenNodes[index] is null)
            {
                childrenNodes[index] = new OctreeNode(level, parent);
            }
            childrenNodes[index].AddColor(color, level + 1, parent);
        }

        private int GetColorIndexForLevel(Color color, int level)
        {
            int index = 0;

            var mask = 0x80 >> level;
            if ((color.Red & mask) != 0)
                index |= 4;
            if ((color.Green & mask) != 0)
                index |= 2;
            if ((color.Blue & mask) != 0)
                index |= 1;

            return index;
        }

        public Color GetColor()
        {
            return new Color(color.Red / pixelCount,
                color.Blue / pixelCount,
                color.Green / pixelCount,
                0);
        }

        public int GetPalletteIndex(Color color, int level)
        {
            if (IsLeaf())
                return palletteIndex;

            int index = GetColorIndexForLevel(color, level);

            if (childrenNodes[index] is not null)
                return childrenNodes[index].GetPalletteIndex(color, level + 1);

            foreach(var child in childrenNodes)
            {
                if (child is not null)
                    return child.GetPalletteIndex(color, level + 1);
            }
            return -1;
        }

        public int RemoveLeaves()
        {
            int result = 0;
            foreach(var child in childrenNodes)
            {
                if(child is not null)
                {
                    this.color.Red += child.color.Red;
                    this.color.Blue += child.color.Blue;
                    this.color.Green += child.color.Green;
                    this.pixelCount += child.pixelCount;
                    result++;
                }
            }
            return result - 1;
        }
        
    }
 
}
