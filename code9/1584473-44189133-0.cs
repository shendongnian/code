    public class MyClass
    {
        public readonly string Id;
        public RectangleF Position { get; set; }
        [JsonConstructor]
        public MyClass(string id, RectangleF? position)
        {
            Id = id;
            Position = position ?? new RectangleF(0, 0, 1, 1);
        }
    }
