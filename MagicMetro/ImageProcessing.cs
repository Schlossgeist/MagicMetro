using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace Schlossgeist.MagicMetro
{
    public static class ImageProcessing
    {
        public struct Color
        {
            public class ColorConverter : IYamlTypeConverter
            {
                public static readonly IYamlTypeConverter Instance = new ColorConverter();

                public bool Accepts(Type type)
                {
                    return type == typeof(Color);
                }

                public object? ReadYaml(IParser parser, Type type)
                {
                    string raw = parser.Consume<Scalar>().Value;
                    raw = raw.Replace(" ", string.Empty).Trim('(', ')');
                    var numStrings = raw.Split(',');

                    return new Color(Byte.Parse(numStrings[0]), Byte.Parse(numStrings[1]), Byte.Parse(numStrings[2]));
                }

                public void WriteYaml(IEmitter emitter, object? value, Type type)
                {
                    emitter.Emit(new MappingStart());

                    Config.Configuration.XMLReplacement.TextPosition textPosition = (Config.Configuration.XMLReplacement.TextPosition) value!;

                    emitter.Emit(new Scalar($"L{textPosition.line} C{textPosition.col}"));
                }
            }

            // R [0-255] G [0-255] B [0-255] to H [0-360] S [0-1] V [0-1]
            private (double H, double S, double V) RGBToHSV(byte R, byte G, byte B)
            {
                double h, s, v;
                byte rgbMin, rgbMax;

                rgbMin = new[] { R, G, B }.Min();
                rgbMax = new[] { R, G, B }.Max();;

                v = rgbMax;
                if (v == 0)
                {
                    h = 0;
                    s = 0;
                    return (h, s, v);
                }

                s = 255 * (rgbMax - rgbMin) / v;
                if (s == 0)
                {
                    h = 0;
                    return (h, s, v);
                }

                if (rgbMax == R)
                    h = 0 + 60 * (double) (G - B) / (rgbMax - rgbMin);
                else if (rgbMax == G)
                    h = 120 + 60 * (double) (B - R) / (rgbMax - rgbMin);
                else
                    h = 240 + 60 * (double) (R - G) / (rgbMax - rgbMin);

                return (h, s / 255, v / 255);
            }

            // H [0-360] S [0-1] V [0-1] to R [0-255] G [0-255] B [0-255]
            private (byte R, byte G, byte B) HSVToRGB(double H, double S, double V)
            {
                byte r, g, b;
                double p, q, t, ff;
                int i;

                if (S == 0)
                {
                    r = (byte) (V * 255);
                    g = (byte) (V * 255);
                    b = (byte) (V * 255);
                    return (r, g, b);
                }

                if (H >= 360) H = 0;
                H /= 60;
                i = (int) H;
                ff = H - i;
                p = V * (1 - S);
                q = V * (1 - S * ff);
                t = V * (1 - S * (1 - ff));

                switch(i) {
                    case 0:
                        r = (byte) (V * 255);
                        g = (byte) (t * 255);
                        b = (byte) (p * 255);
                        break;
                    case 1:
                        r = (byte) (q * 255);
                        g = (byte) (V * 255);
                        b = (byte) (p * 255);
                        break;
                    case 2:
                        r = (byte) (p * 255);
                        g = (byte) (V * 255);
                        b = (byte) (t * 255);
                        break;

                    case 3:
                        r = (byte) (p * 255);
                        g = (byte) (q * 255);
                        b = (byte) (V * 255);
                        break;
                    case 4:
                        r = (byte) (t * 255);
                        g = (byte) (p * 255);
                        b = (byte) (V * 255);
                        break;
                    case 5:
                    default:
                        r = (byte) (V * 255);
                        g = (byte) (p * 255);
                        b = (byte) (q * 255);
                        break;
                }

                return (r, g, b);
            }

            public Color(byte grayValue)
            {
                A = 255;
                R = G = B = grayValue;
                H = S = V = 0F;
                (H, S, V) = RGBToHSV(R, G, B);
            }

            public Color(byte A, byte R, byte G, byte B)
            {
                this.A = A;
                this.R = R;
                this.G = G;
                this.B = B;
                H = S = V = 0F;
                (H, S, V) = RGBToHSV(R, G, B);
            }

            public Color(byte R, byte G, byte B)
            {
                this.A = 255;
                this.R = R;
                this.G = G;
                this.B = B;
                H = S = V = 0F;
                (H, S, V) = RGBToHSV(R, G, B);
            }

            public Color(byte A, double H, double S, double V)
            {
                this.A = A;
                this.H = H < 0 ? -H % 360 : H % 360;
                this.S = Math.Min(Math.Max(S, 0), 1);
                this.V = Math.Min(Math.Max(V, 0), 1);
                R = G = B = 0;
                (R, G, B) = HSVToRGB(H, S, V);
            }

            public Color(double H, double S, double V)
            {
                this.H = H < 0 ? -H % 360 : H % 360;
                this.S = Math.Min(Math.Max(S, 0), 1);
                this.V = Math.Min(Math.Max(V, 0), 1);
                A = 255;
                R = G = B = 0;
                (R, G, B) = HSVToRGB(H, S, V);
            }

            public Color(System.Drawing.Color color)
            {
                A = color.A;
                R = color.R;
                G = color.G;
                B = color.B;
                H = S = V = 0;
                (H, S, V) = RGBToHSV(R, G, B);
            }

            public Color(Windows.UI.Color color)
            {
                A = color.A;
                R = color.R;
                G = color.G;
                B = color.B;
                H = S = V = 0F;
                (H, S, V) = RGBToHSV(R, G, B);
            }

            public byte A { get; }
            public byte R { get; }
            public byte G { get; }
            public byte B { get; }

            public double H { get; }
            public double S { get; }
            public double V { get; }

            public byte this[int i]
            {
                get
                {
                    switch (i)
                    {
                        case 0: return R;
                        case 1: return G;
                        case 2: return B;
                        default: return 0;
                    }
                }
            }

            public override string ToString() {
                return $"({R.ToString()},{G.ToString()},{B.ToString()})";
            }

            public System.Drawing.Color ToSystemColor()
            {
                return System.Drawing.Color.FromArgb(A, R, G, B);
            }
        }

        // Returns a 2D array with the dimensions of the bitmap containing
        // 'true' at every pixel that has a different color than maskColor
        public static bool[][] ColorMask(Bitmap bitmap, Color maskColor, bool compareWithAlphaChannel, byte colorDistanceThreshold)
        {
            var result = new bool[bitmap.Width][];

            for (int i = 0; i < bitmap.Width; i++)
            {
                result[i] = new bool[bitmap.Height];
            }

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    var pixelColor = bitmap.GetPixel(x, y);
                    bool colorIsDifferent = false;

                    if (compareWithAlphaChannel) colorIsDifferent |= Math.Abs(pixelColor.A - maskColor.A) > colorDistanceThreshold;
                    colorIsDifferent |= Math.Abs(pixelColor.R - maskColor.R) > colorDistanceThreshold;
                    colorIsDifferent |= Math.Abs(pixelColor.G - maskColor.G) > colorDistanceThreshold;
                    colorIsDifferent |= Math.Abs(pixelColor.B - maskColor.B) > colorDistanceThreshold;

                    result[x][y] = colorIsDifferent;
                }
            }

            return result;
        }

        public static Bitmap Point(Bitmap bitmap, byte[,] lut, bool oneChannel, bool[][]? mask = null, int colorOffset = 0)
        {
            if (mask != null && (mask.Length != bitmap.Width || mask[0].Length != bitmap.Height))
                throw new Exception("bitmap and mask dimensions do not match");

            var result = new Bitmap(bitmap.Width, bitmap.Height);

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    var oldColor = bitmap.GetPixel(x, y);

                    if (mask != null && !mask[x][y])
                    {
                        result.SetPixel(x, y, oldColor);
                        continue;
                    }

                    System.Drawing.Color newColor;
                    if (oneChannel)
                    {
                        var grayValue = lut[0, oldColor.R] + lut[1, oldColor.G] + lut[2, oldColor.B] + colorOffset;
                        newColor = System.Drawing.Color.FromArgb(oldColor.A, grayValue, grayValue, grayValue);
                    }
                    else
                    {
                        newColor = System.Drawing.Color.FromArgb(
                            oldColor.A,
                            lut[0, oldColor.R] + colorOffset,
                            lut[1, oldColor.G] + colorOffset,
                            lut[2, oldColor.B] + colorOffset
                            );
                    }

                    result.SetPixel(x, y, newColor);
                }
            }

            return result;
        }

        public static Bitmap Rotate(Bitmap bitmap, double degrees, bool[][]? mask = null)
        {
            if (mask != null && (mask.Length != bitmap.Width || mask[0].Length != bitmap.Height))
                throw new Exception("bitmap and mask dimensions do not match");

            var result = new Bitmap(bitmap.Width, bitmap.Height);

            degrees %= 360;

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    var pixelColor = bitmap.GetPixel(x, y);

                    if (mask != null && !mask[x][y])
                    {
                        result.SetPixel(x, y, pixelColor);
                    }
                    else
                    {
                        var color = new Color(pixelColor);
                        result.SetPixel(x, y, new Color(color.A, color.H + degrees, color.S, color.V).ToSystemColor());
                    }
                }
            }

            return result;
        }

        public static Bitmap Saturate(Bitmap bitmap, double saturation, bool[][]? mask = null)
        {
            if (mask != null && (mask.Length != bitmap.Width || mask[0].Length != bitmap.Height))
                throw new Exception("bitmap and mask dimensions do not match");

            var result = new Bitmap(bitmap.Width, bitmap.Height);

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    var pixelColor = bitmap.GetPixel(x, y);

                    if (mask != null && !mask[x][y])
                    {
                        result.SetPixel(x, y, pixelColor);
                    }
                    else
                    {
                        var color = new Color(pixelColor);
                        result.SetPixel(x, y, new Color(color.A, color.H, color.S + saturation, color.V).ToSystemColor());
                    }
                }
            }

            return result;
        }

        public static Bitmap Brighten(Bitmap bitmap, double brightness, bool[][]? mask = null)
        {
            if (mask != null && (mask.Length != bitmap.Width || mask[0].Length != bitmap.Height))
                throw new Exception("bitmap and mask dimensions do not match");

            var result = new Bitmap(bitmap.Width, bitmap.Height);

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    var pixelColor = bitmap.GetPixel(x, y);

                    if (mask != null && !mask[x][y])
                    {
                        result.SetPixel(x, y, pixelColor);
                    }
                    else
                    {
                        var color = new Color(pixelColor);
                        result.SetPixel(x, y, new Color(color.A, color.H, color.S, color.V + brightness).ToSystemColor());
                    }
                }
            }

            return result;
        }

        public static (bool, Color) HasSolidBackground(Bitmap bitmap)
        {
            var colorOccurrence = new Dictionary<Color, int>();
            int transparentPixels = 0;

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    var pixelColor = bitmap.GetPixel(x, y);

                    if (pixelColor.A == 0)
                    {
                        transparentPixels++;
                    }
                    else
                    {
                        var color = new Color(pixelColor);
                        if (!colorOccurrence.ContainsKey(color)) colorOccurrence[color] = 0;

                        colorOccurrence[color]++;
                    }
                }
            }

            if (colorOccurrence.Values.Max() > transparentPixels)
            {
                Color mostOccurrences = colorOccurrence.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
                return (true, mostOccurrences);
            }

            return (false, new Color());
        }

        public static Color GetHighlightColor(Bitmap bitmap)
        {
            var highlightColor = new Color(0);

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    var pixelColor = new Color(bitmap.GetPixel(x, y));

                    if (pixelColor.S > highlightColor.S)
                    {
                        highlightColor = pixelColor;
                    }
                }
            }

            return highlightColor;
        }

        public static byte[][] Histogram(Bitmap bitmap, int channels)
        {
            var result = new byte[channels][];

            for (int channel = 0; channel < channels; channel++)
            {
                result[channel] = new byte[256];
            }

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    var pixel = new Color(bitmap.GetPixel(x, y));

                    for (int channel = 0; channel < channels; channel++)
                    {
                        result[channel][pixel[channel]]++;
                    }
                }
            }

            return result;
        }

        public static Bitmap Equilibrate(Bitmap grayscaleBitmap, bool[][]? mask)
        {
            if (mask != null && (mask.Length != grayscaleBitmap.Width || mask[0].Length != grayscaleBitmap.Height))
                throw new Exception("bitmap and mask dimensions do not match");

            var result = new Bitmap(grayscaleBitmap.Width, grayscaleBitmap.Height);

            var hist = Histogram(grayscaleBitmap, 1)[0];
            var cdc = new float[256];

            int acc = 0;
            float norm = 1F / grayscaleBitmap.Width * grayscaleBitmap.Height;
            for (int i = 0; i < 256; i++)
            {
                acc += hist[i];
                cdc[i] = norm * acc;
            }

            for (int x = 0; x < grayscaleBitmap.Width; x++)
            {
                for (int y = 0; y < grayscaleBitmap.Height; y++)
                {
                    var oldColor = new Color(grayscaleBitmap.GetPixel(x, y));

                    if (mask != null && !mask[x][y])
                    {
                        result.SetPixel(x, y, oldColor.ToSystemColor());
                        continue;
                    }

                    result.SetPixel(x, y, new Color((byte) (255 * cdc[oldColor.R])).ToSystemColor());
                }
            }

            return result;
        }
    }
}