    public class MyProperty
    {
        public enum PropertyType
        {
            String,
            Number
        }
    
        public PropertyType Type { get; set; }
    
        public string StringValue { get; set; }
    
        public double NumberValue { get; set; }
    
        public string PropertyName { get; set; }
    
    }
