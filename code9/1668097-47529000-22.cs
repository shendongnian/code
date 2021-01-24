        R  G  B  A  W
    R  [1  0  0  0  0]
    G  [0  1  0  0  0]
    B  [0  0  1  0  0]
    A  [0  0  0  1  0]
    W  [b  b  b  0  1]    <= Brightness
---
    using System.Drawing;
    using System.Drawing.Imaging;
    // ...
    Image colorImage = Clipboard.GetImage();
    // Default values, no inversion, no threshold adjustment
    var bmpBlackWhite = BitmapToBlackAndWhite(colorImage);
    // Inverted, use threshold adjustment set to .75f
    var bmpBlackWhite = BitmapToBlackAndWhite(colorImage, true, true, .75f);
    // ...
    private Bitmap BitmapToBlackAndWhite(Image image, bool invert = false, bool useThreshold = false, float threshold = .5f)
    {
        var mxBlackWhiteInverted = new float[][]
        {
            new float[] { -1, -1, -1,  0,  0},
            new float[] { -1, -1, -1,  0,  0},
            new float[] { -1, -1, -1,  0,  0},
            new float[] {  0,  0,  0,  1,  0},
            new float[] {  1,  1,  1,  0,  1}
        };
        var mxBlackWhite = new float[][]
        {
            new float[] { 1,  1,  1,  0,  0},
            new float[] { 1,  1,  1,  0,  0},
            new float[] { 1,  1,  1,  0,  0},
            new float[] { 0,  0,  0,  1,  0},
            new float[] {-1, -1, -1,  0,  1}
        };
        using (var bitmap = new Bitmap(image.Width, image.Height))
        using (var g = Graphics.FromImage(bitmap))
        using (var attributes = new ImageAttributes()) {
            attributes.SetColorMatrix(new ColorMatrix(invert ? mxBlackWhiteInverted : mxBlackWhite));
            // Adjust the threshold as needed
            if (useThreshold) attributes.SetThreshold(threshold);
            var rect = new Rectangle(Point.Empty, image.Size);
            g.DrawImage(image, rect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
            return (Bitmap)bitmap.Clone();
        }
    }
