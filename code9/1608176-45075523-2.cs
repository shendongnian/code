    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class ConditionAttribute : System.Attribute
    {
        public readonly string value;
        public ConditionAttribute(string value)
        {
            this.value = value;
        }
    }
