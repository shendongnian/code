    // 
    // ButtonName
    // 
    this.ButtonName.AutoSize = false;
    Image image = new Bitmap(customWidth,customHeight);
    using (Graphics g = Graphics.FromImage(image ))  {
    g.DrawImage(FileLocation, 0, 0, customWidth, customHeight);
    }
    this.ButtonName.Image = image;  
