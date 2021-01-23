     public class dataRaw
        {
            public string data { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
        }
    
        public class collectionGenerator
        {
           public static List<dataRaw> getList()
            {
                var doc = XDocument.Load("Data.xml");
                var dataList = doc.Root
                    .Descendants("Person")
                    .Select(node => new dataRaw
                    {
                        data = node.Element("Number").Value,
                        firstName = node.Element("FirstName").Value,
                        lastName = node.Element("LastName").Value,
                    })
                .ToList();
                return dataList;
            }
        }
