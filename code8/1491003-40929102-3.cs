    Region[] regions;
    
    private void DrawStringWithCharacterBounds(Graphics gr,string text, 
                                               Font font, PointF position)
    {
        using (StringFormat string_format = new StringFormat())
        {
            gr.DrawString(text, font, Brushes.Blue, position);
            List<CharacterRange> range_list = new List<CharacterRange>();
            for (int i = 0; i < text.Length; i++)
            {
                 range_list.Add(new CharacterRange(i, 1));
            }
            string_format.SetMeasurableCharacterRanges(range_list.ToArray());
            SizeF size = gr.MeasureString(text, font);
            // Measure the string's character ranges.
            regions = gr.MeasureCharacterRanges(text, font, new Rectangle(Point.Round(position), 
                                                Size.Round(size)), string_format);
        }
    }
