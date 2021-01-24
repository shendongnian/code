    abstract class DynamicFieldEntity
    {
        protected Dictionary<string, string> DynamicFields { get; } = 
            new Dictionary<string, string>();
    }
    class Class1 : DynamicFieldEntity {}
