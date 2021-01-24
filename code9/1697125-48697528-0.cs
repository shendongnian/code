    string contents = string.Empty;
    using (var ms = new System.IO.MemoryStream())
    {
    	upload.InputStream.CopyTo(ms);
    	ms.Position = 0;
    	
    	contents = new StreamReader(ms).ReadToEnd();
    }
