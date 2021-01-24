    using System;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                var TestBar = new MyXml.Bar()
                {
                    Name = "John Smith",
                };
                Serializer s = new MyXml.Serializer();
                var TestOutput = s.Serialize(TestBar);
                Console.WriteLine(TestOutput);
            }
        }
        public abstract class Bar
        {
            public abstract string Name { get; set; }
        }
        public abstract class Serializer
        {
            public abstract string Serialize(Bar bar);
        }
        namespace MyXml
        {
            public class Serializer : Test.Serializer
            {
                public override string Serialize(Test.Bar bar)
                {
                    string Output = null;
                    var Stream = new MemoryStream();
                    var Encoding = new UTF8Encoding(false, true);
                    // Ignore the Name property in the *base* class!
                    var ao = new XmlAttributeOverrides();
                    var a = new XmlAttributes();
                    a.XmlElements.Clear();
                    a.XmlAttribute = null;
                    a.XmlIgnore = true;
                    ao.Add(typeof(Test.Bar), "Name", a); 
                
                    using (var Writer = new XmlTextWriter(Stream, Encoding))
                    {
                        Writer.Formatting = Formatting.Indented;
                        var s = new XmlSerializer(typeof(Bar), ao);
                        s.Serialize(Writer, bar);
                        Output = Encoding.GetString(Stream.ToArray());
                    }
                    Stream.Dispose();
                    return Output;
                }
            }
            [Serializable]
            [XmlType(AnonymousType = true)] // Make type anonymous!
            [XmlRoot(IsNullable = false)]
            public class Bar : Test.Bar
            {
                [XmlIgnore] // Ignore the Name property in the *derived* class!
                public override string Name
                {
                    get => Unreverse(ReverseName);
                    set => ReverseName = Reverse(value);
                }
                [XmlElement("Name", IsNullable = false)]
                public string ReverseName { get; set; }
                private string Unreverse(string name)
                {
                    return "John Smith"; // Smith, John -> John Smith
                }
                private string Reverse(string name)
                {
                    return "Smith, John"; // John Smith -> Smith, John
                }
            }
        }
    }
