    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class DescriptorAttribute : Attribute
    {
        public bool IsFirst { get; }
        public int UnitType { get; }
    
        public DescriptorAttribute(bool isFirst, int unitType)
        {
            IsFirst = isFirst;
            UnitType = unitType;
        }
    }
