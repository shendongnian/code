    public class CommandAttribute : Attribute
    {
    }
    [System.AttributeUsage(validOn: System.AttributeTargets.Method, AllowMultiple = true)]
    public class CommandAliasAttribute : Attribute
    {
        public CommandAliasAttribute(string alias)
        {
            Alias = alias;
        }
        public string Alias { get;}
    }
