    public class ResourceTemplate
    {
        public string Name;
        public int Value;
    }
    public class ResourceTemplateList : System.Collections.CollectionBase
    {
        public void Add(string name, int value)
        {
            this.List.Add(new ResourceTemplate { Name = name, Value = value });
        }
    }
