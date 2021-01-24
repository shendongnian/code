    public static bool CompareImageFiles(string pathFile1, string pathFile2)
    {
        using (var ms = new MemoryStream())
        using (var img1 = System.Drawing.Image.FromFile(pathFile1))
        using (var img2 = System.Drawing.Image.FromFile(pathFile2))
        {
            // Rest of your code...
        }
    }
