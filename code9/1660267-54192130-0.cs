    public interface IBulkCopy : IDisposable {
        public string DestinationTableName {get;set;}
        public void CreateColumnMapping(string from, string to);
        public Task WriteToServerAsync(DataTable dt);
    }
