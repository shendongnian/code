    public static partial class JsonExtensions
    {
        public static XmlDocument DeserializeXmlNode(string json, string rootName, string rootPropertyName)
        {
            return DeserializeXmlNode(new StringReader(json), rootName, rootPropertyName);
        }
        public static XmlDocument DeserializeXmlNode(TextReader textReader, string rootName, string rootPropertyName)
        {
            var prefix = "{" + JsonConvert.SerializeObject(rootPropertyName) + ":";
            var postfix = "}";
            using (var combinedReader = new StringReader(prefix).Concat(textReader).Concat(new StringReader(postfix)))
            {
                var settings = new JsonSerializerSettings
                {
                    Converters = { new Newtonsoft.Json.Converters.XmlNodeConverter() { DeserializeRootElementName = rootName} },
                    DateParseHandling = DateParseHandling.None,
                };
                using (var jsonReader = new JsonTextReader(combinedReader) { CloseInput = false, DateParseHandling = DateParseHandling.None })
                {
                    return JsonSerializer.CreateDefault(settings).Deserialize<XmlDocument>(jsonReader);
                }
            }
        }
    }
    // Taken from 
    // https://stackoverflow.com/questions/2925652/how-to-string-multiple-textreaders-together/2925722#2925722
    public static class Extensions
    {
        public static TextReader Concat(this TextReader first, TextReader second)
        {
            return new ChainedTextReader(first, second);
        }
        private class ChainedTextReader : TextReader
        {
            private TextReader first;
            private TextReader second;
            private bool readFirst = true;
            public ChainedTextReader(TextReader first, TextReader second)
            {
                this.first = first;
                this.second = second;
            }
            public override int Peek()
            {
                if (readFirst)
                {
                    return first.Peek();
                }
                else
                {
                    return second.Peek();
                }
            }
            public override int Read()
            {
                if (readFirst)
                {
                    int value = first.Read();
                    if (value == -1)
                    {
                        readFirst = false;
                    }
                    else
                    {
                        return value;
                    }
                }
                return second.Read();
            }
            public override void Close()
            {
                first.Close();
                second.Close();
            }
            protected override void Dispose(bool disposing)
            {
                base.Dispose(disposing);
                if (disposing)
                {
                    first.Dispose();
                    second.Dispose();
                }
            }
        }
    }
