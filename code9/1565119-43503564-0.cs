    public class MycustomAttribAttribute : Attribute
    {
        public MycustomAttribAttribute(string name)
        {
            this.Name=name;
        }
        public string Name { get; private set; }
    }
    class A
    {
        public A() { MyProp=new B(); }
        [MycustomAttrib(name: "OK")]
        public B MyProp { get; set; }
    }
    class B
    {
        private static Lazy<MycustomAttribAttribute> att = new Lazy<MycustomAttribAttribute>(() =>
        {
            var types = System.Reflection.Assembly.GetExecutingAssembly().DefinedTypes;
            foreach(var item in types)
            {
                foreach(var prop in item.DeclaredProperties)
                {
                    var attr = prop.GetCustomAttributes(typeof(MycustomAttribAttribute), false);
                    if(attr.Length>0)
                    {
                        return attr[0] as MycustomAttribAttribute;
                    }
                }
            }
            return null;
        });
        public string MyProp2
        {
            get
            {
                return att.Value.Name;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Finds the attribute reference and returns "OK"
            string name = (new A()).MyProp.MyProp2;
            // Uses the stored attribute reference to return "OK"
            string name2 = (new A()).MyProp.MyProp2;
        }
    }
