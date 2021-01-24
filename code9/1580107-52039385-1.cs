    var writer = new BarcodeWriter<UIImage>()
    {
        Format = ZXing.BarcodeFormat.CODE_128,
        Options = new EncodingOptions
		{
            Height = height,
            Width = width,
            Margin = 0
        },
		Renderer = new BarcodeRenderer()
    };
    var image = writer.Write(barcodeValue);
	private class BarcodeRenderer : IBarcodeRenderer<UIImage>
	{
		public UIImage Render(BitMatrix matrix, ZXing.BarcodeFormat format, string content)
		{
			return RenderMatrix(matrix);
		}
		public UIImage Render(BitMatrix matrix, ZXing.BarcodeFormat format, string content, EncodingOptions options)
		{
			return RenderMatrix(matrix);
		}
	}
	/// <summary>
	/// Renders the bitmatrix.
	/// </summary>
    private static UIImage RenderMatrix(BitMatrix matrix)
    {
        var width = matrix.Width;
        var height = matrix.Height;
        var black = new CGColor(0f, 0f, 0f);
        var white = new CGColor(1.0f, 1.0f, 1.0f);
        UIGraphics.BeginImageContext(new CGSize(width, height));
        var context = UIGraphics.GetCurrentContext();
        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                context.SetFillColor(matrix[x, y] ? black : white);
                context.FillRect(new CGRect(x, y, 1, 1));
            }
        }
        var img = UIGraphics.GetImageFromCurrentImageContext();
        UIGraphics.EndImageContext();
        return img;
	}
