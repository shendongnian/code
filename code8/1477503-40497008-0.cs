    protected override void OnLoad(EventArgs e)
    {
        using (var brush = new LinearGradientBrush(this.ClientRectangle,
            Color.Transparent, Color.Transparent, LinearGradientMode.Vertical))
        {
            var blend = new ColorBlend();
            blend.Positions = new[] { 0, 3 / 10f, 1 };
            blend.Colors = new[] { Color.WhiteSmoke, Color.LightSteelBlue, Color.LightSteelBlue };
            brush.InterpolationColors = blend;
            using (var bmp = new Bitmap(ClientRectangle.Width, ClientRectangle.Height))
            {
                var g = Graphics.FromImage(bmp);
                g.FillRectangle(brush, ClientRectangle);
                bmp.Save("background.png", ImageFormat.Png);
            }
        }
    }
