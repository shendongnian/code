    public static IEnumerable<string> GetRows(string path, string rowSeparator)
    {
        bool tryParseSeparator(StreamReader reader, char[] buffer)
        {
            var count = reader.Read(buffer, 0, buffer.Length);
            if (count != buffer.Length)
                return false;
            return Enumerable.SequenceEqual(buffer, rowSeparator);
        }
        using (var reader = new StreamReader(path))
        {
            int peeked;
            var rowBuffer = new StringBuilder();
            var separatorBuffer = new char[rowSeparator.Length];
            while ((peeked = reader.Peek()) > -1)
            {
                if ((char)peeked == rowSeparator[0])
                {
                    if (tryParseSeparator(reader, separatorBuffer))
                    {
                        yield return rowBuffer.ToString();
                        rowBuffer.Clear();
                    }
                    else
                    {
                        rowBuffer.Append(separatorBuffer);
                    }
                }
                else
                {
                    rowBuffer.Append((char)reader.Read());
                }
            }
            if (rowBuffer.Length > 0)
                yield return rowBuffer.ToString();
        }
    }
