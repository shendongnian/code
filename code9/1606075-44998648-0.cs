            XDocument xDoc = XDocument.Load(@"Filepath/XMLFile1.xml");
            List<XElement> LXElement = xDoc.Root.Element("channel").Elements("item").ToList();
            foreach (XElement iElement in LXElement)
            {
                Console.WriteLine(iElement.Element("title").Value);
                Console.WriteLine(iElement.Element("link").Value);
                Console.WriteLine(iElement.Element("guid").Value);
                Console.WriteLine(iElement.Element("pubDate").Value);
                Console.WriteLine(iElement.Element("description").Value);
            }
