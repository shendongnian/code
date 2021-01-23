    public static Image ImageFromBase64String(string base64String)
    {
        byte[] imageBytes = Convert.FromBase64String(base64String);
        using (MemoryStream ms = new MemoryStream(imageBytes))
        {
            return new Bitmap(Image.FromStream(ms, true));
        }
    }
