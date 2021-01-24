    protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            Angle = Angle * Math.PI / 180;
            var startX = 300;
            var startY = 300;
            var endX = 500 + 40 * Math.Sin(Angle);
            var endY = 500 + 40 * Math.Cos(Angle);
            canvas.DrawLine(startX, startY, (float)endX, (float)endY, paint);
        }
