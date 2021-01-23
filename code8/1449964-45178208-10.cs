    // assuming namespace Contosco
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    [XunitTestCaseDiscoverer("Contosco.GenericMethodDiscoverer", "Contosco")]
    public sealed class GenericMethodAttribute : FactAttribute
    {
        public Type[] Types { get; private set; }
        public GenericMethodAttribute(Type[] types)
        {
            Types = types;
        }
    }
