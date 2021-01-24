    public Func<Task<string>> ReadToEndLater(string path)
    {
        retun async () => 
        {
            using(var file = System.IO.File.OpenText(path))
            {
                return await file.ReadToEndAsync();
            }
        }
    }
