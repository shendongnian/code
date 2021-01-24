    try
    {
        Bitmap image1 = (Bitmap) Image.FromFile(@"C:\Documents and Settings\" +
            @"All Users\Documents\My Music\music.bmp", true);
    }
    catch(System.IO.FileNotFoundException)
    {
        MessageBox.Show("There was an error opening the bitmap." +
            "Please check the path.");
    }
 
