    string filep = @"C:\Users\User\Desktop\Gallery\image" + NumberOfClick.ToString() + "cropped.png";
    Bitmap bMap = Bitmap.FromFile(filep) as Bitmap;
    PictureAnalysis.GetMostUsedColor(bMap);
    //Here you get the most used color
    var Color MostUsed = PictureAnalysis.MostUsedColor;
    //Here you get the ten most used colors
    var List<Color> TenMostUsed = PictureAnalysis.TenMostUsedColor;
