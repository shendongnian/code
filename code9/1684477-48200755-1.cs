    namespace XMLDemo
    {
        [System.Xml.Serialization.XmlRoot(ElementName = "return")]
        public struct Return
        {
            [System.Xml.Serialization.XmlElement(ElementName = "name")]
            public string Name { get; set; }
            [System.Xml.Serialization.XmlElement(ElementName = "value")]
            public string Value { get; set; }
        }
    
        [System.Xml.Serialization.XmlRoot(ElementName = "returns")]
        public struct Returns
        {
            [System.Xml.Serialization.XmlElement(ElementName = "return")]
            public System.Collections.Generic.List<Return> Return { get; set; }
        }
    
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public System.DateTime DateOfBirth { get; set; }
            public string Address { get; set; }
    
    
            public Person(Returns data)
            {
                this.FirstName = data.Return[0].Value;
                this.LastName = data.Return[1].Value;
                this.DateOfBirth = System.DateTime.Parse(data.Return[2].Value);
                this.Address = data.Return[3].Value;
            }
        }
    
        class Program
        {
            private const string _FILEPATH = @"D:\data.txt";
            static void Main(string[] args)
            {
                string xml = System.IO.File.ReadAllText(_FILEPATH);
    
                var returns = (Returns)Deserialize(xml, typeof(Returns));
    
                Person person = new Person(returns);
    
                System.Console.WriteLine(person.FirstName);
                System.Console.WriteLine(person.LastName);
                System.Console.WriteLine(person.DateOfBirth);
                System.Console.WriteLine(person.Address);
            }
    
            static object Deserialize(string serializedObj, System.Type type)
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(type);
    
                using (var stringReader = new System.IO.StringReader(serializedObj))
                using (var xmlTextReader = new System.Xml.XmlTextReader(stringReader))
                {
                    return serializer.Deserialize(xmlTextReader);
                }
            }
        }
    }
