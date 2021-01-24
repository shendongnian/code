    public class MaxLengthAttribute: Attribute
    {
        public int Length { get; private set; }
        public MaxLengthAttribute(int length)
        {
            Length = length;
        }
    }
    public class MyData
    {
        [MaxLengthAttribute(5)]
        public string Test { get; set; }
    }
    public static class Validator
    {
        public static void Validate(object o)
        {
            // Returns all public properties of the passed object
            var props = o.GetType().GetProperties();
            foreach(var p in props)
            {
                // Check if this current property has the attribute...
                var attrs = p.GetCustomAttributes(typeof(MaxLengthAttribute), false);
                // Recursive call here if you want to validate nested properties
                if (attrs.Length == 0) continue;
                // Get the attribute and its value
                var attr = (MaxLengthAttribute)attrs[0];
                var length = attr.Length;
                // Get the value of the property that has the attribute
                var current = (string)p.GetValue(o, null);
                // perform the validation
                if (current.Length > length)
                    throw new Exception();
            }
        }
    }
