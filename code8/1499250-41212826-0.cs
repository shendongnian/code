    void positionTo(Label lbl, Panel pan, int pos)
    {
        SizeF sz0, sz1, sz2;
        sz0 = sz1 = sz2 = Size.Empty;
        using (Graphics g = lbl.CreateGraphics())
        {
            StringFormat sf = StringFormat.GenericTypographic;
            sz0 = g.MeasureString(lbl.Text, lbl.Font, pan.Width, sf);
            sz1 = g.MeasureString(lbl.Text.Substring(0, pos), lbl.Font, pan.Width, sf);
            sz2 = g.MeasureString(lbl.Text.Substring(pos), lbl.Font, pan.Width, sf);
        }
        lbl.Left = (int)(pan.Width / 2 - sz1.Width);
    }
