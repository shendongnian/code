    public class JsonStringConverter : IPropertyConverter
    {
        public DynamoDBEntry ToEntry(object value)
        {
            string json = value as string;
            return !String.IsNullOrEmpty(json)
                ? Document.FromJson(json)
                : null;
        }
        public object FromEntry(DynamoDBEntry entry)
        {
            var document = entry.AsDocument();
            return document.ToJson();
        }
    }
