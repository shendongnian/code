    public Func<Task<string>> ReadToEndLater(string path)
    {
        return async () => 
        {
            using(var file = System.IO.File.OpenText(path))
            {
                return await file.ReadToEndAsync();
            }
        }
    }
