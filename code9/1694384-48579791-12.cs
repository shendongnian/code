    public string EditComment(string originalFilepath, string newFilename)
    {
        Byte[] bytes = File.ReadAllBytes(originalFilepath);
        using (MemoryStream stream = new MemoryStream(bytes))
        using (Bitmap image = new Bitmap(stream))
        {
            PropertyItem propItem = image.PropertyItems[0];
            // Processing code
            propItem.Id = 0x9286;  // this is the id for 'UserComment'
            propItem.Type = 2;
            propItem.Value = System.Text.Encoding.UTF8.GetBytes("HelloWorld\0");
            propItem.Len = propItem.Value.Length;
            image.SetPropertyItem(propItem);
            // Not sure where your FilePath comes from but I'm just
            // putting it in the same folder with the new name.
            String newFilepath;
            if (newFilename == null)
                newFilepath = originalFilePath;
            else
                newFilepath = Path.Combine(Path.GetDirectory(originalFilepath), newFilename);
            Image.Save(newFilepath, ImageFormat.Jpeg);
            return newFilepath;
        }
    }
