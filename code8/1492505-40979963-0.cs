    class Foo
    {
        public Size Size { get; set; }
        [JsonProperty(ItemConverterType = typeof(MyConverter))]        
        public List<IShape> Shapes { get; set; }
    }
