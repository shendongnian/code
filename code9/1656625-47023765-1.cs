    public class SomeObject
    {
        public List<DynamicProperty> resultFieldList { get; set; }
    }
    
    public class DynamicProperty
    {
        public string fieldName { get; set; }
    
        public string analyticsDataType { get; set; }
    
        public List<object> values { get; set; }
    }
