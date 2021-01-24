    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public sealed class DescriptionAttribute : Attribute
    {
        public DescriptionAttribute(int weight, string value)
        {
            this.Weight = weight;
            this.Value = value;
        }
        public int Weight { get; }
        public String Value { get; }
    }
