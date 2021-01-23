    public sealed class TransportationInfo
    {
        public string TableName { get; private set; }
        public string PKName    { get; private set; }
        public TransportationInfo(string tableName, string pkName)
        {
            TableName = tableName;
            PKName    = pkName;
        }
    }
