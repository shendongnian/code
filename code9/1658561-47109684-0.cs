    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            MyClass.MyXML xml = myClass["someKeyValue"];
        }
    }
    public class MyClass
    {
        private class Path
        {
            public string db;
        }
        public class MyXML { }
        private static Path path = new Path();
        private static readonly string _xmlfile = $"{path.db}database.xml";
        private Dictionary<string, MyXML> content = new Dictionary<string, MyXML>();
        
        public MyXML this[string key]
        {
            get
            {
                MyXML value = content[key];
                if(key == "someKeyValue" && value == null)
                {
                    value = getXmlFromFile(_xmlfile);
                    content[key] = value;
                }
                return value;
            }
        }
        public MyClass()
        {
        }
        private MyXML getXmlFromFile(string path)
        {
            return XMLHelper.Deserialize<MyXMLs>(path).content;
        }
    }
