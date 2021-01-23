    using System.Text.RegularExpressions;
    using System.Drawing;
    /// <summary>
    /// Draw a string using one or more layout rectangles.  Words which don't fit will overflow into the next layout rectangle.
    /// </summary>
    private static void DrawOverflowString(Graphics graphics, string drawString, RectangleF[] layoutRectangles, StringAlignment alignment)
    {
        var drawFont = new Font("Arial", 16.0f);
        var black = new SolidBrush(Color.Black);
        var format = new StringFormat()
        {
            Alignment = alignment,
            Trimming = StringTrimming.Word,
            FormatFlags = StringFormatFlags.LineLimit
        };
        var wordRegex = new Regex("[^\\s]+");
        string remainingText = drawString;
        foreach (var layoutRect in layoutRectangles)
        {
            // Draw everything that will fit into this text box
            graphics.DrawString(remainingText, drawFont, black, layoutRect, format);
            // calculate which words did not fit
            var wordMatches = wordRegex.Matches(remainingText);
            var ranges = wordMatches.OfType<Match>().Select(x => new CharacterRange(x.Index, x.Length)).ToArray();
            format.SetMeasurableCharacterRanges(ranges);
            var wordRegions = graphics.MeasureCharacterRanges(remainingText, drawFont, layoutRect, format);
            var allfit = true;
            for (int i = 0; i < wordRegions.Length; i++)
            {
                if (wordRegions[i].GetBounds(graphics).Width == 0.0f)
                {
                    allfit = false;
                    remainingText = remainingText.Substring(wordMatches[i].Index);
                    break;
                }
            }
            if (allfit)
                break;
        }
        drawFont.Dispose();
        black.Dispose();
    }
