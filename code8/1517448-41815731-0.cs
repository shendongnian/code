    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    
    namespace ConsoleApplication
    {
        public class Class1
        {
            public List<Class2> List = new List<Class2>();
        }
    
        public class Class2
        {
            public int Ref { get; set; }
            public string Name { get; set; }
            public List<Class3> List { get; set; }
        }
    
        public class Class3
        {
            public int Code { get; set; }
            public float Price { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var obj = new Class1
                {
                    List = new List<Class2>
                    {
                        new Class2
                        {
                            Name = "test",
                            Ref = 1,
                            List = new List<Class3>
                            {
                                new Class3 {Code = 1, Price = 12},
                                new Class3 {Code = 1, Price = 45}
                            }
                        }
                    }
                };
    
                XmlSerializer xmlSer = new XmlSerializer(typeof(Class1));
    
                using (var stream = new MemoryStream())
                {
                    xmlSer.Serialize(stream, obj);
    
                    using (var streamReader = new StreamReader(stream))
                    {
                        stream.Position = 0;
                        var text = streamReader.ReadToEnd();
                    }
                }
            }
        }
    }
