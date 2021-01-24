    public class model
        {
            public object Id { get; set; }
            public object Value { get; set; }
        }
        model n = new model
        {
            Id = reader.GetValue(keyColumn),
            Value = reader.GetValue(snapshotValue)    
        };
