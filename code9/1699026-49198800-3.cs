    public static void CreateImageFromText(String text, String filename, Int32 fontSize)
    {
        // Set global stage dimensions
        Int32 stageWidth = (Int32)(text.Length * 3 * fontSize);
        Int32 stageHeight = (Int32)(3 * fontSize);
        using (Bitmap createdImage = new Bitmap(stageWidth, stageHeight))
        {
            Color blankPixel = createdImage.GetPixel(0, 0);
            // Draw new blank image
            using (Graphics imageCanvas = Graphics.FromImage(createdImage))
            {
                imageCanvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                imageCanvas.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                // Add text
                if (!string.IsNullOrEmpty(text))
                {
                    if (text.StartsWith("tick:"))
                        using (Font bigFont = new Font("Arial", (Int32)(fontSize * (decimal)1.25)))
                            imageCanvas.DrawString("✔", bigFont, Brushes.Green, 0, 0);
                    else if (text.StartsWith("cross:"))
                        using (Font bigFont = new Font("Arial", (Int32)(fontSize * (decimal)1.25)))
                            imageCanvas.DrawString("X", bigFont, Brushes.Red, 0, 0);
                    else if (text.StartsWith("highlight:"))
                        using (Font veryBigFont = new Font("Arial", (Int32)(fontSize * (decimal)3)))
                            imageCanvas.DrawString("•", veryBigFont, Brushes.Magenta, 0, 0);
                    else
                        using (Font font = new Font("Arial", (Int32)fontSize))
                            imageCanvas.DrawString(text, font, Brushes.Black, 0, 0);
                }
            }
            // Honestly not sure what the point of this is, especially given the complete inaccuracy of the original image size calculation.
            Rectangle? searchArea = text.StartsWith("highlight:") ? new Rectangle(10, 20, createdImage.Width - 10, createdImage.Height - 20) : (Rectangle?)null;
            Rectangle r = ImageUtils.GetCropBounds(createdImage, blankPixel, searchArea: searchArea);
            // Save cropped
            using (Image img = createdImage.Clone(r, createdImage.PixelFormat))
                img.Save(filename, ImageFormat.Png);
        }
    }
