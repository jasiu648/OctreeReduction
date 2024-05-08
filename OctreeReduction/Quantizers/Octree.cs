using OctreeReduction.Utils;
using Color = OctreeReduction.Utils.Color;

namespace OctreeReduction.Quantizers
{
    public class OctreeNode
    {
        OctreeNode[] childrenNodes;
        public Color color;
        int pixelCount;
        public int palletteIndex;

        public OctreeNode(int level, Quantizer parent)
        {
            color = new Color(0, 0, 0);
            pixelCount = 0;
            palletteIndex = 0;
            childrenNodes = new OctreeNode[8];

            if (level < parent.MAX_DEPTH - 1)
                parent.Levels[level].Add(this);
        }

        public bool IsLeaf() => pixelCount > 0;
        public List<OctreeNode> GetLeaves()
        {
            List<OctreeNode> Leaves = new List<OctreeNode>();
            foreach (var child in childrenNodes)
            {
                if (child is null)
                    continue;

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

        public void AddColor(Color color, int level, Quantizer parent)
        {
            if (level >= parent.MAX_DEPTH)
            {
                this.color.Red += color.Red;
                this.color.Green += color.Green;
                this.color.Blue += color.Blue;
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
                color.Green / pixelCount,
                color.Blue / pixelCount);
        }

        public int GetPalletteIndex(Color color, int level)
        {
            if (IsLeaf())
                return palletteIndex;

            int index = GetColorIndexForLevel(color, level);

            if (childrenNodes[index] is not null)
                return childrenNodes[index].GetPalletteIndex(color, level + 1);

            foreach (var child in childrenNodes)
            {
                if (child is not null)
                    return child.GetPalletteIndex(color, level + 1);
            }
            return -1;
        }

        public int RemoveLeaves()
        {
            int result = 0;
            foreach (var child in childrenNodes)
            {
                if (child is not null)
                {
                    color.Red += child.color.Red;
                    color.Blue += child.color.Blue;
                    color.Green += child.color.Green;
                    pixelCount += child.pixelCount;
                    result++;
                }
            }
            return result - 1;
        }

    }

}
