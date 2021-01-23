    public class Root
    {
        public Dictionary<string, ValueWrapper> Object { get; set; }
    }
    public class ValueWrapper
    {
        public PropertyValues Values { get; set; }
    }
    public class PropertyValues
    {
        public int Value { get; set; }
        public string DisplayValue { get; set; }
    }
