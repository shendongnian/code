                using (Bitmap textBmp = new Bitmap(textSize.Width, textSize.Height,PixelFormat.Format32bppPArgb)) {
                    
                    using (Graphics textGraphics = Graphics.FromImage(textBmp)) {
                        // now draw the text..
                        textGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                        TextRenderer.DrawText(textGraphics, text, textFont, new Rectangle(Point.Empty, textSize), textColor, textFormat);
                        textBmp.RotateFlip((e.TextDirection == ToolStripTextDirection.Vertical90) ? RotateFlipType.Rotate90FlipNone :  RotateFlipType.Rotate270FlipNone);
                        g.DrawImage(textBmp, textRect);
                    }
                }
