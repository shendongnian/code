    public static partial class JsonExtensions
    {
        public static void ToNewlineDelimitedJson<T>(Stream stream, IEnumerable<T> items)
        {
			// Let caller dispose the underlying stream	
            using (var textWriter = new StreamWriter(stream, new UTF8Encoding(false, true), 1024, true))
			{
	            ToNewlineDelimitedJson(textWriter, items);
			}
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
                // http://specs.okfnlabs.org/ndjson/
                // Each JSON text MUST conform to the [RFC7159] standard and MUST be written to the stream followed by the newline character \n (0x0A). 
                // The newline charater MAY be preceeded by a carriage return \r (0x0D). The JSON texts MUST NOT contain newlines or carriage returns.
                textWriter.Write("\n");
            }
        }
    }
