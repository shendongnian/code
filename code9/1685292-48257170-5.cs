    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
        e.DrawBackground();
        Rectangle _Bounds = new Rectangle(e.Bounds.X - GraphicsPaddingOffset,
                                            e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
        string _ItemString = listBox1.GetItemText(listBox1.Items[e.Index]);
        List<int> _TheIndexList = Regex.Matches(_ItemString, _TheChars)
                                        .Cast<Match>()
                                        .Select(s => s.Index).ToList();
        StringFormat _SFormat = new StringFormat(StringFormat.GenericDefault);
        if (_TheIndexList.Count > 0)
        {
            CharacterRange[] _CharRanges = new CharacterRange[_TheIndexList.Count];
            for (int _CharX = 0; _CharX < _TheIndexList.Count; _CharX++)
                _CharRanges[_CharX] = new CharacterRange(_TheIndexList[_CharX], _TheChars.Length);
            _SFormat = new StringFormat(StringFormat.GenericDefault);
            _SFormat.SetMeasurableCharacterRanges(_CharRanges);
            Region[] _Regions = e.Graphics.MeasureCharacterRanges(_ItemString, e.Font, e.Bounds, _SFormat);
            RectangleF[] _RectsF = new RectangleF[_Regions.Length];
            for (int _RFx = 0; _RFx < _Regions.Length; _RFx++)
                _RectsF[_RFx] = _Regions[_RFx].GetBounds(e.Graphics);
            e.Graphics.FillRectangles(Brushes.LightGreen, _RectsF);
        }
        e.Graphics.DrawString(_ItemString, e.Font, new SolidBrush(e.ForeColor), _Bounds, _SFormat);
    }
