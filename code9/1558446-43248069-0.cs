    public static void SearchNodes()
            {
                XDocument doc = XDocument.Load(@"D:\\Test\\Test2.xml");
    
                var v = from nodes in doc.Descendants("TestCase")
                        where nodes.Attribute("UID").Value == "06a4df3b-f072-4f70-a5c3-f0f2ea95654c"
                        select nodes;
    
                foreach (var item in v)
                {
                    Console.Write(item);    
                }
               
            }
