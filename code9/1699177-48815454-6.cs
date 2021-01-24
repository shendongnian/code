    [AttributeUsage(AttributeTargets.Property)]
    public sealed class CsvColumnAttribute : System.Attribute
    {
        public String Name { get; private set; }
        public CsvColumnAttribute(String name)
        {
            this.Name = name;
        }
    }
