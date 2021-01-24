    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
        e.DrawBackground();
        e.DrawFocusRectangle();
    
        var itemStr = listBox1.Items[e.Index].ToString();
        var strings = itemStr.Split(' '); // Here I split item text
        var bound = e.Bounds;
    
        foreach (var s in strings)
        {
            var strRenderLegnth = e.Graphics.MeasureString(s, new Font(FontFamily.GenericSansSerif, 10)).Width;
    
            e.Graphics.DrawString // Draw each substring with customized settings
            (
                s,
                new Font(FontFamily.GenericSansSerif, 10),
                new SolidBrush(Color.Red), // Use verius colors for each substring
                bound
            );
    
            bound = new Rectangle(e.Bounds.X + (int)strRenderLegnth, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
        }
    }
