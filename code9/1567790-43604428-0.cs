    public static async Task<XDocument> LoadAsync
     ( String path
     , LoadOptions loadOptions = LoadOptions.PreserveWhitespace
     )
    {
        return Task.Run(()=>{
         using (var stream = File.OpenText(path))
            {
                return XDocument.Load(stream, loadOptions);
            }
        });
    }
