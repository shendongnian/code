    using System;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace XmlSerializationProject
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Create test details array
                var TestDetails = new Xml.Detail[]
                {
                    new Xml.Detail
                    {
                        Description = "bald"
                    },
                    new Xml.Detail
                    {
                        Description = "red tie"
                    }
                };
    
                // create test person object that holds details array
                var TestBar = new Xml.Person()
                {
                    Details = TestDetails
                };
    
                // serialize the person object
                var s = new Xml.Serializer();
                var TestOutput = s.Serialize(TestBar);
    
                Console.WriteLine(TestOutput);
                Console.ReadKey();
            }
        }
    
        // base classes
        public abstract class Person
        {
            public abstract Detail[] Details { get; set; }
        }
    
        public abstract class Detail
        {
            public abstract string Description { get; set; }
        }
    
        namespace Xml
        {
            [Serializable]
            [XmlType(AnonymousType = true)]
            [XmlRoot(IsNullable = false)]
            public class Person : XmlSerializationProject.Person
            {
                public Person()
                { }
    
                public Person(XmlSerializationProject.Person person)
                {
                    // Deep copy
                    if (person.Details == null) return;
                    this.Details = new Detail[person.Details.Length];
                    for (int i = 0; i < person.Details.Length; i++)
                    {
                        this.Details[i] = new Detail { Description = person.Details[i].Description };
                    }
                }
    
                [XmlArray(ElementName = "Details")]
                [XmlArrayItem("Detail", typeof(Detail))]
                [XmlArrayItem("ODetail", typeof(XmlSerializationProject.Detail))]
                public override XmlSerializationProject.Detail[] Details
                {
                    get;
                    set;
                }
            }
    
            [Serializable]
            public class Detail : XmlSerializationProject.Detail
            {
                public override string Description { get; set; }
            }
    
            // class that does serializing work
            public class Serializer
            {
                private static readonly XmlSerializer PersonSerializer;
    
                private static Serializer()
                {
                    var xmlAttributeOverrides = new XmlAttributeOverrides();
                    // Change original "Detail" class's element name to "AbstractDetail"
                    var xmlAttributesOriginalDetail = new XmlAttributes();
                    xmlAttributesOriginalDetail.XmlType = new XmlTypeAttribute() { TypeName = "AbstractDetail" };
                    xmlAttributeOverrides.Add(typeof(XmlSerializationProject.Detail), xmlAttributesOriginalDetail);
    
                    // Ignore Person.Details array
                    var xmlAttributesOriginalDetailsArray = new XmlAttributes();
                    xmlAttributesOriginalDetailsArray.XmlIgnore = true;
                    xmlAttributeOverrides.Add(typeof(XmlSerializationProject.Person), "Details", xmlAttributesOriginalDetailsArray);
    
                    PersonSerializer = new XmlSerializer(
                        typeof(Person), xmlAttributeOverrides, new Type[] { typeof(Detail) }, new XmlRootAttribute(), "default");
                }
    
                public string Serialize(XmlSerializationProject.Person person)
                {
                    return Serialize(new Person(person));
                }
    
                public string Serialize(Person person)
                {
                    string Output = null;
                    var Stream = new MemoryStream();
                    var Encoding = new UTF8Encoding(false, true);
    
                    using (var Writer = new XmlTextWriter(Stream, Encoding))
                    {
                        Writer.Formatting = Formatting.Indented;
                        PersonSerializer.Serialize(Writer, person);
                        Output = Encoding.GetString(Stream.ToArray());
                    }
                    Stream.Dispose();
                    return Output;
                }
            }
        }
    }
