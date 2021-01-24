	protected override void OnDraw(Android.Graphics.Canvas canvas)
	{
		base.OnDraw(canvas);
		using (var colorPaint = new Paint())
		{
			colorPaint.Color = Color.Rgb(255, 0, 0);
			colorPaint.TextSize = 30;
			canvas.DrawText("StackOverflow", 12, 32, colorPaint);
			colorPaint.Color = Color.Rgb(255, 255, 255);
			canvas.DrawText("StackOverflow", 10, 30, colorPaint);
		}
	}
