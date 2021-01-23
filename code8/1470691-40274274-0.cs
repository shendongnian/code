    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public sealed class RequiredIfEmptyAttribute : RequiredAttribute
    {
        public RequiredIfEmptyAttribute()
        {
            TypeId = new object();
        }
        public override object TypeId { get; }
        // all the rest of the code
    }
