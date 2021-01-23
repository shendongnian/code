    // grab all controls from Colum 2 (index == 1)
    List<Control> Col_2_Stuff = tableLayoutPanel1.Controls.OfType<Control>()
                 .Where(x => tableLayoutPanel1.GetPositionFromControl(x).Column == 1).ToList();
    // make them invisible
    Col_2_Stuff.Select(c => { c.Visible = false; c = null; return c; }).ToList();
