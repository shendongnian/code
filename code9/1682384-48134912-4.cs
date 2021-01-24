    public class Product
    {
        private List<Dictionary<string, string>> _propertiesData = new List<Dictionary<string, string>>();
        public int Id { get; set; }
        public List<Dictionary<string, string>> PropertiesData { get { return _propertiesData; } }
    }
