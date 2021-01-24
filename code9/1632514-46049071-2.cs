    public void SaveToFile(string fullFileName)
    {
        _Wpd.MainDocumentPart.Document.Save();
    
        _Wpd.Package.Flush();
    
        _Ms.Position = 0;
        var buf = new byte[_Ms.Length];
        _Ms.Read(buf, 0, buf.Length);
    
        using (FileStream fs = new System.IO.FileStream(fullFileName, System.IO.FileMode.Create))
        {
            fs.Write(buf, 0, buf.Length);
        }
    }
