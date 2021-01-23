    public class SampleTable : TableEntity
    {
        public SampleTable(string partitionKey, string rowKey, string randomCode)
        {
            PartitionKey = partitionKey;
            RowKey = rowKey;
            RandomCode = randomCode;
        }
        public SampleTable() { }
        public string RandomCode { get; set; }
    }
