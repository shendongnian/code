        public class KeyValuePairWrapper {
            public int Key { get; set; }
            public String Value { get; set; }
            //default constructor will be required for binding, the Web.MVC binder will invoke this and set the Key and Value accordingly.
            public KeyValuePairWrapper() { }
            //a convenience method which allows you to set the values while sorting
            public KeyValuePairWrapper(int key, String value)
            {
                Key = key;
                Value = value;
            }
        }
