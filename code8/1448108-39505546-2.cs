    public string GetImage(string path)
    {
      using (Image image = Image.FromFile(path))
        {                 
            using (MemoryStream m = new MemoryStream())
            {
                image.Save(m, image.RawFormat);
                byte[] imageBytes = m.ToArray();
    
                // Convert byte[] to Base64 String
                return Convert.ToBase64String(imageBytes);                
            }                  
        }
    }
