    if (_TheIndexList.Count > 0)
    {
        using (Graphics _G = TextBox1.CreateGraphics())
        {
            foreach (int _Pos in _TheIndexList)
            {
                PointF _P = TextBox1.GetPositionFromCharIndex(_Pos);
                SizeF _S = _G.MeasureString(_TheChar.ToString(), TextBox1.Font, 0,
                                            StringFormat.GenericTypographic);
                _G.FillRectangle(Brushes.LightGreen, new RectangleF(_P, _S));
                _G.DrawString(_TheChar.ToString(), TextBox1.Font, new SolidBrush(TextBox1.ForeColor),
                              _P, StringFormat.GenericTypographic);
            }
        }
    }
