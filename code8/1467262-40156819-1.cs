    public static class SquidWebProxyServerCommaSeparatedWriter
    {
        public static void WriteToCSV(string destination, IEnumerable<SquidWebProxyServerLogEntry> serverLogEntries)
        {
            var lines = serverLogEntries.Select(ConvertToLine);
            File.WriteAllLines(destination, lines);
        }
        private static string ConvertToLine(SquidWebProxyServerLogEntry serverLogEntry)
        {
            return string.Join(@",", serverLogEntry.Timestamp, serverLogEntry.Elapsed.ToString(),
                serverLogEntry.ClientIPAddress, serverLogEntry.ActionCode, serverLogEntry.Size.ToString(),
                serverLogEntry.Method.ToString(), serverLogEntry.Uri, serverLogEntry.Identity,
                serverLogEntry.HierarchyFrom, serverLogEntry.MimeType);
        }
    }    
    public static class SquidWebProxyServerLogParser
    {
        public static IEnumerable<SquidWebProxyServerLogEntry> Parse(FileInfo fileInfo)
        {
            using (var streamReader = fileInfo.OpenText())
            {
                string row;
                while ((row = streamReader.ReadLine()) != null)
                {
                    yield return ParseRow(row)
                }
            }
        }
        private static SquidWebProxyServerLogEntry ParseRow(string row)
        {
            var fields = row.Split(new[] {"\t", " "}, StringSplitOptions.None);
            return new SquidWebProxyServerLogEntry
            {
                Timestamp = fields[0],
                Elapsed = int.Parse(fields[1]),
                ClientIPAddress = fields[2],
                ActionCode = fields[3],
                Size = int.Parse(fields[4]),
                Method =
                    (SquidWebProxyServerLogEntry.MethodType)
                    Enum.Parse(typeof(SquidWebProxyServerLogEntry.MethodType), fields[5]),
                Uri = fields[6],
                Identity = fields[7],
                HierarchyFrom = fields[8],
                MimeType = fields[9]
            };
        }
        public static IEnumerable<SquidWebProxyServerLogEntry> Parse(IEnumerable<string> rows) => rows.Select(ParseRow);
    }
    public sealed class SquidWebProxyServerLogEntry
    {
        public enum MethodType
        {
            Get = 0,
            Post = 1,
            Put = 2
        }
        public string Timestamp { get; set; }
        public int Elapsed { get; set; }
        public string ClientIPAddress { get; set; }
        public string ActionCode { get; set; }
        public int Size { get; set; }
        public MethodType Method { get; set; }
        public string Uri { get; set; }
        public string Identity { get; set; }
        public string HierarchyFrom { get; set; }
        public string MimeType { get; set; }
    }
