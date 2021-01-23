    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public sealed class RequiredIfEmptyAttribute : RequiredAttribute
    {
        private object _instance = new object();
        public override bool Equals(object obj) => _instance.Equals(obj);
        public override int GetHashCode() => _instance.GetHashCode();
        // all the rest of the code
    }
