    Panel pn = new Panel()
        {
            Width = _PNTemp.Width,
            Height = _PNTemp.Height,
            Left = 0,
            Top = 0,
            BackColor = _PNTemp.BackColor,
            ForeColor = _PNTemp.ForeColor,
            AutoScroll = true,
            Name = _PNTemp.Name,
            Tag = _PrgPanels.Count.ToString()
        };
        MessageBox.Show(_PNTemp.Controls.Count.ToString());
        //all the controls are still inside _PNTemp
        foreach (Control c in _PNTemp.Controls)
        {
            pn.Controls.Add(c);
            MessageBox.Show(_PNTemp.Controls.Count.ToString());
            //Each time this runs you remove a control from _PNTemp to pn. 
        }
        //All the controls moved from _PnTemp to pn
        MessageBox.Show(_PNTemp.Controls.Count.ToString());
        _PrgPanels.Add(pn);
