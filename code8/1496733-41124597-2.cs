    try
    {
        using (var bitmap = new System.Drawing.Bitmap(myFile.InputStream))
        {
        }
    }
    catch (Exception)
    {
        return false;
    }
