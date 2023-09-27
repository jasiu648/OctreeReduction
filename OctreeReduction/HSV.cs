using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HSV
{
    public class HSV
    {
        public static void ColorToHSV(System.Drawing.Color color, out double hue, out double saturation, out double value)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

            hue = color.GetHue();
            saturation = (max == 0) ? 0 : 1d - (1d * min / max);
            value = max / 255d;
        }

        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }

        public static Color HsvToRgb(double H, double S, double V)
        {
            while (H < 0) { H += 360; };
            while (H >= 360) { H -= 360; };
            double R, G, B;
            if (V <= 0)
            { R = G = B = 0; }
            else if (S <= 0)
            {
                R = G = B = V;
            }
            else
            {
                double hf = H / 60.0;
                int i = (int)Math.Floor(hf);
                double f = hf - i;
                double pv = V * (1 - S);
                double qv = V * (1 - S * f);
                double tv = V * (1 - S * (1 - f));
                switch (i)
                {

                    // Red is the dominant color

                    case 0:
                        R = V;
                        G = tv;
                        B = pv;
                        break;

                    // Green is the dominant color

                    case 1:
                        R = qv;
                        G = V;
                        B = pv;
                        break;
                    case 2:
                        R = pv;
                        G = V;
                        B = tv;
                        break;

                    // Blue is the dominant color

                    case 3:
                        R = pv;
                        G = qv;
                        B = V;
                        break;
                    case 4:
                        R = tv;
                        G = pv;
                        B = V;
                        break;

                    // Red is the dominant color

                    case 5:
                        R = V;
                        G = pv;
                        B = qv;
                        break;

                    // Just in case we overshoot on our math by a little, we put these here. Since its a switch it won't slow us down at all to put these here.

                    case 6:
                        R = V;
                        G = tv;
                        B = pv;
                        break;
                    case -1:
                        R = V;
                        G = pv;
                        B = qv;
                        break;

                    // The color is not defined, we should throw an error.

                    default:
                        //LFATAL("i Value error in Pixel conversion, Value is %d", i);
                        R = G = B = V; // Just pretend its black/white
                        break;
                }
            }
            int r = Clamp((int)(R * 255.0));
            int g = Clamp((int)(G * 255.0));
            int b = Clamp((int)(B * 255.0));

            return Color.FromArgb(255, r, g, b);
        }

        public static int Clamp(int i)
        {
            if (i < 0) return 0;
            if (i > 255) return 255;
            return i;
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    GenerateHSV();
        //}

        //public void GenerateHSV()
        //{
        //    hsvBitmap = new Bitmap(300, 300);
        //    HSVbox.Image = hsvBitmap;

        //    int middle = 150;
        //    int radius = 100;
        //    int radiusS = radius * radius;
        //    for (int x = 0; x < 300; x++)
        //        for (int y = 0; y < 300; y++)
        //        {

        //            if((x - middle) * (x - middle) + (y-middle) * (y - middle) < radiusS)
        //            {                           
        //                double h1 = Math.Asin( (middle - x) / Math.Sqrt((y - middle) * (y - middle) + (x - middle) * (x - middle)));

        //                h1 += (Math.PI / 2);
        //                double h = h1 * (180 / Math.PI);
        //                if(y > middle)
        //                {
        //                    h = h + 2* (180 - h);
        //                }
        //                if (x == middle && y == middle)
        //                    h = 0;
        //                hsvBitmap.SetPixel(x, y, HSV.HSV.HsvToRgb(h, Math.Sqrt((y - middle) * (y - middle) + (x - middle) * (x - middle)) / 100, (double)Value / 100));
        //            }
        //            else
        //            {
        //                hsvBitmap.SetPixel(x, y, System.Drawing.Color.White);
        //            }
        //        }
        //}
    }
}
