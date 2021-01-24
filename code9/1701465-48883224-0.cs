    public static Person Deserialize(Stream stream)
    {
            var httpRequest = HttpContext.Current.Request;
            // This list will have all the stream objects
            var persons = new List<Person>();
            if (httpRequest.Files.Count > 0)
            {
                for (var obj = 0; doc < httpRequest.Files.Count; obj++)
                {
                    var postedFile = httpRequest.Files[obj];
                    var bytes = new byte[postedFile.ContentLength];
                    postedFile.InputStream.Read(bytes, 0, postedFile.ContentLength);
                    persons.Add(Serializer.Deserialize<Person>(new JsonTextReader(new StreamReader(new MemoryStream(bytes)))));
                }
            }
    }
    
