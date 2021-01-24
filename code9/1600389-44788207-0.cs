    public static partial class JsonExtensions
    {
        public static void ToNewlineDelimitedJson<T>(Stream stream, IEnumerable<T> items)
        {
            var textWriter = new StreamWriter(stream);
            ToNewlineDelimitedJson(textWriter, items);
            textWriter.Flush(); // Let the caller dispose the stream
        }
        public static void ToNewlineDelimitedJson<T>(TextWriter textWriter, IEnumerable<T> items)
        {
            var serializer = JsonSerializer.CreateDefault();
            foreach (var item in items)
            {
                // Formatting.None is the default; I set it here for clarity.
                using (var writer = new JsonTextWriter(textWriter) { Formatting = Formatting.None, CloseOutput = false })
                {
                    serializer.Serialize(writer, item);
                }
                textWriter.WriteLine();
            }
        }
    }
