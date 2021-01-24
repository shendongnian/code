            var fileName = "XMLFile1.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            XmlNodeList elemList = doc.GetElementsByTagName("OrderID");
            for (int i = 0; i < elemList.Count; i++)
            {
                Console.WriteLine(elemList[i].InnerText);
            }
