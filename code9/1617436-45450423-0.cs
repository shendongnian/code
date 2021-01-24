    public static Task<SomeObject> DeserializeAsync(string path) {
        JsonSerializer json = new JsonSerializer();
        using(var reader = new JsonTextReader(new StreamReader(path))) {
            var obj = json.Deserialize(reader, typeof(SomeObject));
            return Task.FromResult((SomeObject)obj);
        }
    }
