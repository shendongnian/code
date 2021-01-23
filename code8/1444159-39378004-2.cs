    public interface IProperty
    {
        object Value { get; }
        Type TypeOfValue { get; }
    }
    public class Property : IProperty
    {
        public object Value { get; set; }
        public Type TypeOfValue { get; set; }
		public override string ToString() { return TypeOfValue.FullName + ": " + Value; }
    }
    public class Observable
    {
        public readonly Dictionary<string, Property> 
            Properties = new Dictionary<string, Property>();
    
		// use interface so consumer of your property can't mess with the
		// type or value stored in your dictionary within Observable
        public IProperty Get(string name)
        {
            Property obj;
            if (Properties.TryGetValue(name, out obj)){
                return obj;
            }
    
            // throw something which makes more sense to you
            throw new ArgumentException(name + " does not exist in the dictionary");
        }
        // sample of how you'd store these properties
        public void Set(string name, object val)
        {
            if (Properties.ContainsKey(name)){
                Properties[name].Value = val;
                Properties[name].TypeOfValue = val.GetType();
            } else {
                Properties[name] = new Property {
                    Value = val,
                    TypeOfValue = val.GetType()
                };
            }
        }
    }
