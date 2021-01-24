    private static Task<SomeObject> LoadFileAsync(string path) {
        return Task.Run(() => {
            JsonSerializer json = new JsonSerializer();
            using(var reader = new JsonTextReader(new StreamReader(path))) {
                var obj = json.Deserialize(reader, typeof(SomeObject));
                return (SomeObject)obj;
            }
        });        
    }
    public static async Task<SomeObject> DeserializeAsync(string filePath)
    {
       var obj = await LoadFileAsync(filePath);
       return obj;
    }
