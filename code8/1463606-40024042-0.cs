    for (int i = 0; i < imgCount; i++)
    {
       // padding left will give you 001 and 010 and 151
       string img = i.ToString().PadLeft(3, '0');
       BitmapImage carBitmap = new BitmapImage(new Uri("pack://application:,,,/Images/All_Sprites/" + img+".png", UriKind.Absolute));
       // the rest of your code
    }
