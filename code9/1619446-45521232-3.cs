    [AttributeUsage(AttributeTargets.Class | Inherited = true)]
    public class DbTableAttribute: System.Attribute
    {
        private readonly string _name;
        public string Name { get { return _name; } }
        public DbTableAttribute(string name)
        {
            _name = name;
        }
    }
