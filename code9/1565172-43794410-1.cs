    [DynamoDBTable("TableName")]
    public class LogDb
    {
        [DynamoDBHashKey("Id")]
        public long Id{ get; set; }
        [DynamoDBProperty(AttributeName = "Data", Converter = typeof(JsonStringConverter))]
        public string DataJson { get; set; }
    }
