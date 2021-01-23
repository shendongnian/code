        public Image Base64ToImage(string base64String)
     {
        // Convert base 64 string to byte[]
        test = base64String.Split(',')[1];byte[] imageBytes = 
           Convert.FromBase64String(test);
        byte[] imageBytes = Convert.FromBase64String(base64String);
        // Convert byte[] to Image
        using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
        {
            Image image = Image.FromStream(ms, true);
            return image;
        }
     }
