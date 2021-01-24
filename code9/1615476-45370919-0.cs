     byte[] bytes = Convert.FromBase64String(base64String);
        Image image;
        using (MemoryStream ms = new MemoryStream(bytes))
        {
            image = Image.FromStream(ms);
        }
        image.Save(fullOutputPath+imagename, System.Drawing.Imaging.ImageFormat.Png);
