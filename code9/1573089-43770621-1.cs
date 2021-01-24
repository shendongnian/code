    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    class Program
    {
        static void Main()
        {
            var xsr = new XmlSerializer(typeof(Base));
            var b = new Base
            {
                children = new List<Child>
                    {
                        new Child { Name= "Joe"},
                        new Child { Name ="Jack"},
                    }
            };
            using (var ms = new MemoryStream())
            {
                xsr.Serialize(ms, b);
                var str = Encoding.UTF8.GetString(ms.ToArray());
                /*
                <?xml version="1.0"?>
                <Base xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
                  <Child>
                    <Name>Joe</Name>
                  </Child>
                  <Child>
                    <Name>Jack</Name>
                  </Child>
                </Base>
                 */
            }
        }
    }
    public class Base
    {
        [XmlElement("Child")]
        public List<Child> children;
    }
    public class Child
    {
        public string Name;
    }
