    void Rotate(Bitmap bmp)
    {
        PropertyItem pi = bmp.PropertyItems.Select(x => x)
                                           .FirstOrDefault(x => x.Id == 0x0112);
        if (pi == null) return; 
        byte o = pi.Value[0];
        if (o==2) bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
        if (o==3) bmp.RotateFlip(RotateFlipType.RotateNoneFlipXY);
        if (o==4) bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
        if (o==5) bmp.RotateFlip(RotateFlipType.Rotate90FlipX);
        if (o==6) bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
        if (o==7) bmp.RotateFlip(RotateFlipType.Rotate90FlipY);
        if (o==8) bmp.RotateFlip(RotateFlipType.Rotate90FlipXY);
    }
