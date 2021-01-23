    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    public class MyData {
        public string A { get; set; }
        [DefaultValue("b")]
        public string B { get; set; }
        public string C { get; set; }
    
        public bool ShouldSerializeC() => C != "c";
    
        public string D { get; set; }
    
        public bool ShouldSerializeD() => D != "asdas";
    
    }
    class Program {
        static void Main() {
            var obj = new MyData {
                A = "a", B = "b", C = "c", D = "d"
            };
            new XmlSerializer(obj.GetType())
                .Serialize(Console.Out, obj);
        }
    }
