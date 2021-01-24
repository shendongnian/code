    using (FileStream fs = new FileStream(filePath, 
            FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read))    
    {    
        using (StreamReader sr = new StreamReader(fs))
        {
           ... // all the reading
        }
        fs.Position = 0; 
        using (StreamWriter sw = new StreamWriter(fs))
        {
            sw.Write(string.Join("\r\n", lines));
        }
        fs.SetLength(fs.Position); // untested, something along this line
    }
