    public class UglySolution
    {
        private static string _changedString;
        private class CustomAttribute : Attribute
        {
            public CustomAttribute()
            {
                _changedString = "New";
            }
        }
        public class SomeClass
        {
            public SomeClass()
            {
                _changedString = "Original";
            }
            [Custom]
            public string GetValue()
            {
                typeof(SomeClass).GetMethod("GetValue").GetCustomAttributes(true).OfType<CustomAttribute>().First();
                return _changedString;
            }
        }
    }
