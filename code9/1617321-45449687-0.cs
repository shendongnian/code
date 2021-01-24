    stream = new StreamReader(file.InputStream);
    using (stream)
    {
        while (stream.Peek() >= 0)
        {
            var line =  stream.ReadLine();
            //some stuff              
        }
    }
    
