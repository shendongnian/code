    float marginLR = 36;
    float marginB = 2;
    float footerHeight = 34;
    Rectangle pagesize = reader.GetCropBox(i);
    if (pagesize == null) {
        pagesize = reader.GetPageSize(i);
    }
    Rectangle rect = new Rectangle(
        pagesize.Left + marginLR, pagesize.Bottom + margin,
        pagesize.Right - marginLR, pagesize.Bottom + margin + footerheight
    );
