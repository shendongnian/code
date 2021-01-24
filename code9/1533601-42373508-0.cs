    public static List<string> WordWrap(this string sourceCode, Font font, int width, Graphics g)
        {
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            var format = StringFormat.GenericTypographic;
            format.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
            var width = g.MeasureString(word, font, 0, format).Width;
        }
