        byte[] bytes = Convert.FromBase64String(base64);
        Image image;
        using (MemoryStream ms = new MemoryStream(bytes))
        {
            image = Image.FromStream(ms);
            image.Save("~/Content/", System.Drawing.Imaging.ImageFormat.Png);
        }
        
