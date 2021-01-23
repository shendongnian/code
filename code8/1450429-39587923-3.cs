    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Text;
    namespace ConsoleApplication1
    {
        public class Person
        {
            [DataMember]
            public Guid Id { get; set; }
            [DataMember]
            public string Name { get; set; }
            [IgnoreDataMember]
            public string Address { get; set; }
            [IgnoreDataMember]
            public int PinCode { get; set; }
            [DataMember]
            public string Phone { get; set; }
        }
        class Program
        {
            // list of properties of Person class marked with DataMemeber attribute
            private PropertyInfo[] _personProperties = typeof(Person)
                .GetProperties()
                .Where(x => x.GetCustomAttribute(typeof(DataMemberAttribute)) != null).ToArray();
												
            public string Serialize(string separator, IEnumerable<Person> objectlist)
            {
                StringBuilder tsvdata = new StringBuilder();
            
                string header = string.Join(separator, _personProperties.Select(x => x.Name).ToArray());
                tsvdata.AppendLine(header);
                foreach (var o in objectlist)
                {
                    List<string> lineValues = new List<string>();
                    // enumerate through the properties
                    foreach (var pi in _personProperties)
                    {
                        lineValues.Add(pi.GetValue(o).ToString());
                    }
                    tsvdata.AppendLine(string.Join(separator, lineValues.ToArray()));
                }
                return tsvdata.ToString();
            }
            static void Main(string[] args)
            {
                Program p = new Program();
                List<Person> persons = new List<Person> {
                    new Person { Id = Guid.NewGuid(), Address = "a1", Name = "name1", Phone = "tel1", PinCode = 1111 },
                    new Person { Id = Guid.NewGuid(), Address = "a2", Name = "name2", Phone = "tel2", PinCode = 2222 },
                };
                string serializedString = p.Serialize(", ", persons);
                Console.WriteLine($"result: {serializedString}");
            }
        }
    }
