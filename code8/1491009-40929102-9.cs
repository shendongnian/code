    // Measure the characters in a string with
    // no more than 32 characters.
    private List<RectangleF> MeasureCharactersInWord(
        Graphics gr, Font font, string text)
    {
        List<RectangleF> result = new List<RectangleF>();
        using (StringFormat string_format = new StringFormat())
        {
            string_format.Alignment = StringAlignment.Near;
            string_format.LineAlignment = StringAlignment.Near;
            string_format.Trimming = StringTrimming.None;
            string_format.FormatFlags =
                StringFormatFlags.MeasureTrailingSpaces;
            CharacterRange[] ranges = new CharacterRange[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                ranges[i] = new CharacterRange(i, 1);
            }
            string_format.SetMeasurableCharacterRanges(ranges);
                
            RectangleF rect = new RectangleF(0, 0, 10000, 100);
            Region[] regions =
                gr.MeasureCharacterRanges(
                    text, font, this.ClientRectangle,
                    string_format);
                
            foreach (Region region in regions)
                result.Add(region.GetBounds(gr));
        }
        return result;
    }
