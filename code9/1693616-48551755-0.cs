    public string ImageToBase64(string path)   
    {  
        using(System.Drawing.Image image = System.Drawing.Image.FromFile(path))  
        {  
            using(MemoryStream m = new MemoryStream())  
            {  
                image.Save(m, image.RawFormat);  
                byte[] imageBytes = m.ToArray();  
                return Convert.ToBase64String(imageBytes);   
            }  
        }  
    }  
