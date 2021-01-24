        public class Employee
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
        public class Employees
        {
            [XmlElement("Employee")]
            public Employee[] Items { get; set; }
        }
        static void DoXmlToJson()
        {
            string xmlData = @"<Employees>
                                <Employee>
                                    <FirstName>name1</FirstName>
                                    <LastName>surname1</LastName>
                                </Employee>
                                <Employee>
                                    <FirstName>name2</FirstName>
                                    //<LastName>surname2</LastName>
                                </Employee>
                                <Employee>
                                    <FirstName>name3</FirstName>
                                    <LastName>surname3</LastName>
                                </Employee>
                            </Employees>";
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employees));
            MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xmlData));
            Employees wholeObject = (Employees)xmlSerializer.Deserialize(memoryStream);
            string json = JsonConvert.SerializeObject(wholeObject.Items);
            Console.WriteLine(json);
        }
