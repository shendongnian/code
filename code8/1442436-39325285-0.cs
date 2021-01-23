    foreach(string fileName in fileEntries)
    {
    ibImageList = new ImageButton();
    ibImageList.ImageUrl = GetDirectoryName(fileName);
    ibImageList.Width = new Unit(125, UnitType.Pixel);
    ibImageList.CommandName = GetDirectoryName(fileName);
    //Add it to the panel
    pnlImages.Controls.Add(ibImageList);
    pnlImages.Controls.Add(new LiteralControl("<br>"));
    }
    
