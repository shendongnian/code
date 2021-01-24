        class Employee
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
        static void DoXmlToJson()
        {
            string xmlData = @"<?xml version='1.0' encoding='UTF-8'?>
                              <Employees>
                                <Employee>
                                    <FirstName>name1</FirstName>
                                    <LastName>surname1</LastName>
                                </Employee>
                                <Employee>
                                    <FirstName>name2</FirstName>
                                    <LastName>surname2</LastName>
                                </Employee>
                                <Employee>
                                    <FirstName>name3</FirstName>
                                    <LastName>surname3</LastName>
                                </Employee>
                            </Employees>";
            XDocument doc = XDocument.Parse(xmlData);
            var array = doc.Root.Elements()
                .Select(row => new Employee() {
                    FirstName = row.Element("FirstName").Value,
                    LastName = row.Element("LastName").Value
                });
            string json = JsonConvert.SerializeObject(array);
            Console.WriteLine(json);
        }
