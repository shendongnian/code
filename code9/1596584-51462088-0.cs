    public static string Minify(string json)
    {
        return ReformatJson(json, Formatting.None);
    }
    public static string Beautify(string json)
    {
        return ReformatJson(json, Formatting.Indented);
    }
    public static string ReformatJson(string json, Formatting formatting)
    {
        using (StringReader stringReader = new StringReader(json))
        using (StringWriter stringWriter = new StringWriter())
        {
            ReformatJson(stringReader, stringWriter, formatting);
            return stringWriter.ToString();
        }
    }
    public static void ReformatJson(TextReader textReader, TextWriter textWriter, Formatting formatting)
    {
        using (JsonReader jsonReader = new JsonTextReader(textReader))
        using (JsonWriter jsonWriter = new JsonTextWriter(textWriter))
        {
            jsonWriter.Formatting = formatting;
            jsonWriter.WriteToken(jsonReader);
        }
    }
