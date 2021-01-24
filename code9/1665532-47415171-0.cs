    string subPath = "C:/Temp/";
    if (!Directory.Exists(subPath))
    {
        Directory.CreateDirectory(subPath);
    }
    
    string filepath = "C:/Temp/ordine.pdf";
    
    using (FileStream fs = new FileStream(filepath, FileMode.Create))
    {
        fs.WriteAsync(bytes, 0, bytes.Length);
        fs.Close();
    }
    
    File.Delete(@"C:/Temp/ordine.pdf");
