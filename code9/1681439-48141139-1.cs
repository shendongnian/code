	public class TextSample : SampleBase
	{
        // ...
		protected override void OnDrawSample(SKCanvas canvas, int width, int height)
		{
			canvas.DrawColor(SKColors.White);
			const string text = "象形字";
			var x = width / 2f;
            // in my case the line below returns typeface with FamilyName `Yu Gothic UI`
			var typeface = SKFontManager.Default.MatchCharacter(text[0]);
			using (var paint = new SKPaint())
			{
				paint.TextSize = 64.0f;
				paint.IsAntialias = true;
				paint.Color = (SKColor)0xFF4281A4;
				paint.IsStroke = false;
				paint.Typeface = typeface; // use typeface for the first one
				paint.TextAlign = SKTextAlign.Center;
				canvas.DrawText(text, x, 64.0f, paint);
			}
			using (var paint = new SKPaint())
			{
                // no typeface here
				paint.TextSize = 64.0f;
				paint.IsAntialias = true;
				paint.Color = (SKColor)0xFF9CAFB7;
				paint.IsStroke = true;
				paint.StrokeWidth = 3;
				paint.TextAlign = SKTextAlign.Center;
				canvas.DrawText(text, x, 144.0f, paint);
			}
		}
	}
