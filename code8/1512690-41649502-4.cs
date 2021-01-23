    public static class StreamReaderExtensions
    {
        public static string ReadLineWithNewLine(this StreamReader reader)
        {
            var builder = new StringBuilder();
            while (!reader.EndOfStream)
            {
                int c = reader.Read();
                builder.Append((char) c);
                if (c == 10)
                {
                    break;
                }
            }
            return builder.ToString();
        }
    }
