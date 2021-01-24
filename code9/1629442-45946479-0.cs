        public static T ReadPath<T>(Serializer serializer, string yaml, string path) {
            var eventReader = new EventReader(new Parser(new StringReader(yaml)));
            var streamReader = new MemoryStream(Encoding.UTF8.GetBytes(path ?? ""));
            if ((char)streamReader.ReadByte() != '$')
                throw new Exception();
            if (streamReader.Position == streamReader.Length)
                return serializer.Deserialize<T>(eventReader);
            eventReader.Expect<StreamStart>();
            eventReader.Expect<DocumentStart>();
            while (streamReader.Position < streamReader.Length) {
                if ((char)streamReader.ReadByte() != '.')
                    throw new Exception();
                eventReader.Expect<MappingStart>();
                var currentDepth = eventReader.CurrentDepth;
                var nextKey = ReadPropertyName(streamReader);
                if (string.IsNullOrEmpty(nextKey))
                    throw new Exception();
                while (eventReader.Peek<Scalar>() == null || eventReader.Peek<Scalar>().Value != nextKey) {
                    eventReader.Skip();
                    // We've left the current mapping without finding the key.
                    if (eventReader.CurrentDepth < currentDepth)
                        throw new Exception();
                }
                eventReader.Expect<Scalar>();
            }
            return serializer.Deserialize<T>(eventReader);
        }
        public static string ReadPropertyName(MemoryStream stream) {
            var sb = new StringBuilder();
            while (stream.Position < stream.Length) {
                var nextChar = (char) stream.ReadByte();
                if (nextChar == '.') {
                    stream.Position--;
                    return sb.ToString();
                }
                sb.Append(nextChar);
            }
            return sb.ToString();
        }
