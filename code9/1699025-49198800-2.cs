    public static void CreateImageFromText(String text, String filename, Int32 fontSize, Int32 padding)
    {
        if (text == null)
            text = String.Empty;
        Boolean prefixTick = text.StartsWith("tick:");
        Boolean prefixCross = !prefixTick && text.StartsWith("cross:");
        Boolean highlight = !prefixTick && !prefixCross && text.StartsWith("highlight:");
        const String symbTick = "✔";
        const String symbCross = "X";
        const String symbBullet = "•";
        // Cut off the prefix part
        if (prefixTick || prefixCross || highlight)
            text = text.Substring(text.IndexOf(":", StringComparison.Ordinal) + 1).TrimStart();
        using (Font font = new Font("Arial", fontSize))
        using (Font prefixFont = new Font("Arial", fontSize * (highlight ? 3f : 1.25f), highlight ? FontStyle.Bold : FontStyle.Regular))
        {
            // Calculate accurate dimensions of required image.
            Single textWidth;
            Single prefixWidth = 0;
            Single requiredHeight = 0;
            Single textHeight;
            Single prefixHeight = 0;
            // Dummy image will have the same dpi as the final one.
            using (Bitmap dummy = new Bitmap(1, 1))
            using (Graphics g = Graphics.FromImage(dummy))
            {
                if (prefixTick)
                {
                    SizeF tickSize = g.MeasureString(symbTick, prefixFont);
                    requiredHeight = Math.Max(tickSize.Height, requiredHeight);
                    prefixWidth = tickSize.Width;
                }
                else if (prefixCross)
                {
                    SizeF crossSize = g.MeasureString(symbCross, prefixFont);
                    requiredHeight = Math.Max(crossSize.Height, requiredHeight);
                    prefixWidth = crossSize.Width;
                }
                else if (highlight)
                {
                    SizeF bulletSize = g.MeasureString(symbBullet, prefixFont);
                    requiredHeight = Math.Max(bulletSize.Height, requiredHeight);
                    prefixWidth = bulletSize.Width;
                }
                prefixHeight = requiredHeight;
                SizeF textSize = g.MeasureString(text.Length == 0 ? " " : text, font);
                textWidth = text.Length == 0 ? 0 : textSize.Width;
                textHeight= textSize.Height;
                requiredHeight = Math.Max(textSize.Height, requiredHeight);
            }
            if (!prefixTick && !prefixCross && !highlight && text.Length == 0)
            {
                Int32 width = padding*2;
                Int32 height = (Int32)Math.Round(textHeight + padding*2, MidpointRounding.AwayFromZero);
                if (width == 0)
                    width = 1;
                // Creates an image of the expected height for the font, and a width consisting of only the padding, or 1 for no padding.
                using (Image img = new Bitmap(width, height))
                    img.Save(filename, ImageFormat.Png);
                return;
            }
            Single prefixX = 5;
            Single prefixY = 5 + padding + prefixWidth > 0 && requiredHeight > prefixHeight ? (requiredHeight - prefixHeight) / 2 : 0;
            Single textX = 5 + prefixWidth;
            Single textY = 5 + padding + requiredHeight > textHeight ? (requiredHeight - textHeight) / 2 : 0;
            // Set global stage dimensions. Add 10 Pixels to each to allow for 5-pixel border.
            Int32 stageWidth = (Int32)Math.Round(prefixWidth + textWidth, MidpointRounding.AwayFromZero) + 10 + padding * 2;
            Int32 stageHeight = (Int32)Math.Round(requiredHeight, MidpointRounding.AwayFromZero) + 10 + padding * 2;
            // Create Bitmap placeholder for new image       
            using (Bitmap createdImage = new Bitmap(stageWidth, stageHeight))
            {
                Color blankPixel = createdImage.GetPixel(0, 0);
                // Draw new blank image
                using (Graphics imageCanvas = Graphics.FromImage(createdImage))
                {
                    imageCanvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    imageCanvas.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                    // Add text
                    if (prefixTick)
                        imageCanvas.DrawString(symbTick, prefixFont, Brushes.Green, prefixX, prefixY);
                    else if (prefixCross)
                        imageCanvas.DrawString(symbCross, prefixFont, Brushes.Red, prefixX, prefixY);
                    else if (highlight)
                        imageCanvas.DrawString(symbBullet, prefixFont, Brushes.Magenta, prefixX, prefixY);
                    if (text.Length > 0) 
                        imageCanvas.DrawString(text, font, Brushes.Black, textX, textY);
                }
                //clip to only part containing text. 
                Rectangle r = ImageUtils.GetCropBounds(createdImage, blankPixel, padding);
                if (r.Width <= 0 || r.Height <= 0)
                    return; // Possibly throw exception; image formats can't handle 0x0.
                // Save cropped
                createdImage.Save(Path.Combine(Path.GetDirectoryName(filename), Path.GetFileNameWithoutExtension(filename)) + "_orig" + Path.GetExtension(filename), ImageFormat.Png);
                using (Image img = createdImage.Clone(r, createdImage.PixelFormat))
                    img.Save(filename, ImageFormat.Png);
            }
        }
    }
