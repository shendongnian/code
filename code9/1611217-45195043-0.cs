    public static class ToolsEx
    {
        public static IEnumerable<string> ReadAsLines(this string filename)
        {
            using (var streamReader = new StreamReader(filename))
                while (!streamReader.EndOfStream)
                    yield return streamReader.ReadLine();
        }
    }
