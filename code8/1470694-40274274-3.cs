    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public sealed class RequiredIfEmptyAttribute : RequiredAttribute
    {
        public override object TypeId { get; } = new object();
        // all the rest of the code
    }
