    public class Source
    {
        public Dictionary<string, string>[] Properties { get; set; }
        public SourceProduct[] Products { get; set; }
    }
    public class SourceProduct
    {
        public int Id { get; set; }
        public int[] PropertiesIndexes { get; set; }
    }
