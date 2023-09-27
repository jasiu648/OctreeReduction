
namespace OctreeReduction
{
    public interface IQuantizer
    {
        public Bitmap Quantize(Bitmap bitmap, int width, int heigth, int colorsCount = 256);
    }
}
