    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    
    class Program {
        static void Main() {
            var xml = @"<bla>
        <ListOfListOfTest>
             <ListOfTest> 
                   <Test>       
                   </Test>        
            </ListOfTest>        
        </ListOfListOfTest>
    </bla>";
            var bar = (Bar)new XmlSerializer(typeof(Bar)).Deserialize(new StringReader(xml));
            Console.WriteLine(bar.Lists.Sum(_ => _.Items.Count)); // 1
        }
    }
    [XmlRoot("bla")]
    public class Bar {
        [XmlArray("ListOfListOfTest")]
        [XmlArrayItem("ListOfTest")]
        public List<Foo> Lists { get; } = new List<Foo>();
    }
    public class Foo {
        [XmlElement("Test")]
        public List<Test> Items { get; } = new List<Test>();
    }
    public class Test { }
