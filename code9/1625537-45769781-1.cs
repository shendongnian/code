    Region region = Region.FromHrgn(hRgn);//err here once
    if (!region.IsEmpty(gfxBmp))
    {
        gfxBmp.ExcludeClip(region);
        gfxBmp.Clear(Color.Transparent);
    }
    gfxBmp.Dispose();
    region.Dispose();  //Try adding this in.
    return bmp;
