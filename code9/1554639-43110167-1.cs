            XmlDocument doc = new XmlDocument();
            doc.Load("your XML File Name with extension");
            XmlNodeList elemList = doc.GetElementsByTagName("OrderID");
            for (int i = 0; i < elemList.Count; i++)
            {
                Console.WriteLine(elemList[i].InnerText);
            }
