        public class GlyphRunner : DrawingVisual
        {
            public GlyphRunner(string text, Brush bc, Size size)
            {
                DrawingImage di = CreateGlyph(text, new Point(0, 0), bc);
                using (DrawingContext dc = RenderOpen())
                {
                    dc.DrawImage(di,new Rect(size));
                }
            }
            // small updates to your code follow     
            public DrawingImage CreateGlyph(string text, Point origin, Brush bc)
            {
                Typeface typeface = new Typeface(new FontFamily("Arial"),
                                     FontStyles.Normal,
                                     FontWeights.Normal,
                                     FontStretches.Normal);
    
                GlyphTypeface glyphTypeface;
                if (!typeface.TryGetGlyphTypeface(out glyphTypeface))
                    throw new InvalidOperationException("No glyphtypeface found");
    
                ushort[] glyphIndexes = new ushort[text.Length];
                double[] advanceWidths = new double[text.Length];
    
                double totalWidth = 0;
    
                for (int n = 0; n < text.Length; n++)
                {
                    ushort glyphIndex = glyphTypeface.CharacterToGlyphMap[text[n]];
                    glyphIndexes[n] = glyphIndex;
    
                    double width = glyphTypeface.AdvanceWidths[glyphIndex];
                    advanceWidths[n] = width;
    
                    totalWidth += width;
                }
    
                float ppd = (float)VisualTreeHelper.GetDpi(this).PixelsPerDip;
                GlyphRun gr =  new GlyphRun(glyphTypeface, 0, false, 1.0, ppd, glyphIndexes, origin, advanceWidths, null, null, null, null, null, null);
                GlyphRunDrawing glyphRunDrawing = new GlyphRunDrawing(bc, gr);
                return new DrawingImage(glyphRunDrawing);
            }
    
        }
