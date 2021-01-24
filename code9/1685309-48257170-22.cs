    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
        e.DrawBackground();
        TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.Top | TextFormatFlags.NoPadding |
                                TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl;
        Rectangle bounds = new Rectangle(e.Bounds.X + TextRendererPaddingOffset, 
                                         e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
        string ItemString = listBox1.GetItemText(listBox1.Items[e.Index]);
        List<int> TheIndexList = Regex.Matches(ItemString, HighLightString)
                                      .Cast<Match>()
                                      .Select(s => s.Index).ToList();
        if (TheIndexList.Count > 0)
        {
            CharacterRange[] CharRanges = new CharacterRange[TheIndexList.Count];
            for (int CharX = 0; CharX < TheIndexList.Count; CharX++)
                CharRanges[CharX] = new CharacterRange(TheIndexList[CharX], HighLightString.Length);
            StringFormat format = new StringFormat(StringFormat.GenericDefault);
            format.SetMeasurableCharacterRanges(CharRanges);
            Region[] regions = e.Graphics.MeasureCharacterRanges(ItemString, e.Font, e.Bounds, format);
            RectangleF[] rectsF = new RectangleF[regions.Length];
            for (int RFx = 0; RFx < regions.Length; RFx++)
                rectsF[RFx] = regions[RFx].GetBounds(e.Graphics);
            e.Graphics.FillRectangles(Brushes.LightGreen, rectsF);
        }
        TextRenderer.DrawText(e.Graphics, ItemString, e.Font, bounds, e.ForeColor, flags);
    }
