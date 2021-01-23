    public class dataRaw
        {
            public string data { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
        }
    
        //You can call this class with x = collectionGenerator.getList() (it returns a list<T>)
        public class collectionGenerator
        {
           public static List<dataRaw> getList()
            {
                //This is the xml file in the folder
                var doc = XDocument.Load("Data.xml"); 
    
                //This parse the XML and adds in to the list "dataList"
                var dataList = doc.Root
                    .Descendants("Person")
                    .Select(node => new dataRaw
                    {
                        //data, firstName and lastName are in app variables from dataRaw put into listData.
                        //Number, FirstName and LastName are the nodes in the XML file.
                        data = node.Element("Number").Value,
                        firstName = node.Element("FirstName").Value,
                        lastName = node.Element("LastName").Value,
                    })
                .ToList();
                return dataList;
            }
        }
