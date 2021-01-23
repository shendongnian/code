    XDocument doc = new XDocument(new XElement("div", new XAttribute("TYPE", "BODY_CONTENT")));
                XElement title = doc
                   .Descendants("div")
                   .Where(x => (string)x.Attribute("TYPE") == "BODY_CONTENT")
                   .FirstOrDefault();
                int i = 1;
                foreach (Family item in trvFamilies.Items)
                {
                    title.Add(new XElement("div",  new XAttribute("TYPE", "PARAGRAPH"), new XAttribute("ORDER", i.ToString())));
                    XElement text = doc
                            .Descendants("div")
                            .Where(x => (string)x.Attribute("ORDER") == i.ToString())
                        .FirstOrDefault();
                    title.Add(new XElement("div", new XAttribute("TYPE", "TEXT"), new XElement("fptr", new  XAttribute("order", i.ToString()))));
    
                    foreach (var itm in item.Members)
                    {
                        XElement area = doc
                          .Descendants("fptr")
                          .Where(x => (string)x.Attribute("order") == i.ToString())
                          .FirstOrDefault();
                        area.AddFirst(new XElement("area", new XAttribute("name", itm.Name)));
                    }
                    i++;
                }
                Console.WriteLine(doc);
