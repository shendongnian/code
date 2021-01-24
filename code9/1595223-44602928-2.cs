    public class Widget
    {
        [BsonId(IdGenerator=typeof(StringObjectIdGenerator))]
        public string WidgetId { get; set; }
        public string Foo { get; set; }
    }
