    string path = AppDomain.CurrentDomain.BaseDirectory + "ENV500008.jpg";
    if (System.IO.File.Exists(path))
    {
        Image image = Image.FromFile();
        // .. the rest of the code that uses the image .. 
    }
