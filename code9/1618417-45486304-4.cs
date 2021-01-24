    [AttributeUsage(AttributeTargets.Method)]
    public sealed class InvocationOrderAttribute : Attribute
    {
        public int Order { get; private set; }
        public InvocationOrderAttribute(int order)
        {
            Order = order;
        }
    }
