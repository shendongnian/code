    List<string> imgFiles = new List<string>()
    { yourImageFileName1, ...};
    for (int i = 0; i  < imgFiles.Count; i++)
    {
        Image img = Bitmap.FromFile(imgFiles[i]);
        chart1.Images.Add(new NamedImage("Image" + i, img));
    }
