    public static IList<Person> Deserialize(Stream stream) {
        var serializer = new JsonSerializer();
        var streamReader = new StreamReader(stream, new UTF8Encoding());
        var result = new List<Person>();
        using (var reader = new JsonTextReader(streamReader)) {
            reader.CloseInput = false;
            // important part
            reader.SupportMultipleContent = true;
            while (reader.Read()) {
                result.Add(serializer.Deserialize<Person>(reader));
            }
        }
        return result;
    }
