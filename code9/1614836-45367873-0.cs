    class Program
    {
        public static Dictionary<string, Type> animals = new Dictionary<string, Type>();
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            Type[] typ = assembly.GetTypes();
            foreach (Type t in typ)
            {
                // check if the type has attribute of Method type
                var attrData = t.GetTypeInfo().CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(Method));
                if(attrData==null || !attrData.NamedArguments.Any(x => string.Equals(x.MemberName, nameof(Method.Name)))) continue;
                
                animals.Add(attrData.NamedArguments[0].TypedValue.Value.ToString(), t);
            }
        }
    }
