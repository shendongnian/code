    using (var mem = new MemoryStream())
                using (var reader = new StreamReader(mem))
                {
                    Request.Body.CopyTo(mem);
                    var body = reader.ReadToEnd();
    
    //and this you can reset the position of the stream.
                    mem.Seek(0, SeekOrigin.Begin);
                    body = reader.ReadToEnd();
                }
