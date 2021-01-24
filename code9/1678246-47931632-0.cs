    public class SomeAttribute : Attribute
    {
        public SomeAttribute() { }
        public SomeAttribute(string category, string fileName)
        {
            Category = category;
            FileName = fileName;
        }
        public string Category { get;  }
        public string FileName { get;  }
    }
