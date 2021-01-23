	public class InkImage
	{
		public static BitmapFrame MergeInk(StrokeCollection ink, BitmapSource background)
		{
			DrawingVisual drawingVisual = new DrawingVisual();
			using (DrawingContext drawingContext = drawingVisual.RenderOpen())
			{
				drawingContext.DrawImage(background, new Rect(0, 0, background.Width, background.Height));
				foreach (var item in ink)
				{
					item.Draw(drawingContext);
				}
				drawingContext.Close();
				var bitmap = new RenderTargetBitmap((int)background.Width, (int)background.Height, background.DpiX, background.DpiY, PixelFormats.Pbgra32);
				bitmap.Render(drawingVisual);
				return BitmapFrame.Create(bitmap);
			}
		}
	}
