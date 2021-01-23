    using (var brush = new LinearGradientBrush(this.ClientRectangle,
        Color.Transparent, Color.Transparent, LinearGradientMode.Vertical))
    {
        var blend = new ColorBlend();
        blend.Positions = new[] { 0, 3 / 4f, 1 };
        blend.Colors = new[] { Color.White, Color.Black, Color.Black };
        brush.InterpolationColors = blend;
        e.Graphics.FillRectangle(brush, this.ClientRectangle);
    }
