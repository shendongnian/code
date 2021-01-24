    class Program
    {
        public static Dictionary<String, string> animals = new Dictionary<string, string>();
        static void Main(string[] args)
        {
           
            Assembly assembly = Assembly.GetEntryAssembly();
            Type[] typ = assembly.GetTypes();
            foreach (Type t in typ)
            {
                IList<CustomAttributeData> m = t.GetCustomAttributesData();
                if(m.Count>0)
                animals.Add(t.Name, m[0].NamedArguments[0].TypedValue.Value.ToString());
                
            }
          
        }
        
    }
    public class Method : Attribute
    {
        public string Name { get; set; }
        public Method()
        {
            Name = "";
        }
    }
    //Class Dog
    [Method(Name = "dog")]
    public class Dog
    {
        public int NumberOfLegs { get; set; }
        public string Breed { get; set; }
        public Dog() { }
    }   
