	protected override void OnDraw(Android.Graphics.Canvas canvas)
	{
		base.OnDraw(canvas); // call base here you want to draw the subclassed View content under your custom drawing
		using (var colorPaint = new Paint())
		{
			colorPaint.Color = Color.Rgb(255, 0, 0);
			colorPaint.TextSize = 30;
			canvas.DrawText("StackOverflow", 10, 30, colorPaint);
		}
		//base.OnDraw(canvas); // call base here you want to draw the subclassed View content over your custom drawing
	}
