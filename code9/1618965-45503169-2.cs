            // path to file
            string path = @"C:\t\1.txt";
            XDocument _doc = XDocument.Load(path);
            List<XElement> testIds = new List<XElement>();
            // get all test elements
            testIds = _doc.Descendants("test").ToList();
            // loop true test elements
            foreach (XElement extId in testIds.Distinct())
            {
                // get element values
                
                string id = extId.Attribute("id").Value;
                string name = extId.Element("name").Value;
                string age = extId.Element("age").Value;
                string info = extId.Element("informations").Value;
                Console.WriteLine(id+ "," + name + ", " + " " + age + ", " + info);
            }
