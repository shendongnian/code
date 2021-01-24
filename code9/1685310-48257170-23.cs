    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
        e.DrawBackground();
        Rectangle bounds = new Rectangle(e.Bounds.X - GraphicsPaddingOffset,
                                         e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
        string ItemString = listBox1.GetItemText(listBox1.Items[e.Index]);
        List<int> TheIndexList = Regex.Matches(ItemString, HighLightString)
                                      .Cast<Match>()
                                      .Select(s => s.Index).ToList();
        StringFormat format = new StringFormat(StringFormat.GenericDefault);
        if (TheIndexList.Count > 0)
        {
            CharacterRange[] CharRanges = new CharacterRange[TheIndexList.Count];
            for (int CharX = 0; CharX < TheIndexList.Count; CharX++)
                CharRanges[CharX] = new CharacterRange(TheIndexList[CharX], HighLightString.Length);
            format.SetMeasurableCharacterRanges(CharRanges);
            Region[] regions = e.Graphics.MeasureCharacterRanges(ItemString, e.Font, e.Bounds, format);
            RectangleF[] rectsF = new RectangleF[regions.Length];
            for (int RFx = 0; RFx < regions.Length; RFx++)
                rectsF[RFx] = regions[RFx].GetBounds(e.Graphics);
            e.Graphics.FillRectangles(Brushes.LightGreen, rectsF);
        }
        using (SolidBrush brush = new SolidBrush(e.ForeColor))
            e.Graphics.DrawString(ItemString, e.Font, brush, bounds, format);
    }
