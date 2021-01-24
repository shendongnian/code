    class BaseClass
    {
    }
    class DerivedClass : BaseClass
    {
        public string PropertyX { get; set; }
    }
    static class UsePropertyName
    {
        public static string GetPropertyName(BaseClass classInstance)
        {
            //Instance not actually used.
            return nameof(DerivedClass.PropertyX);
        }
    }
