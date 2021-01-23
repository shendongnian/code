    XNamespace ns =  "http://schemas.microsoft.com/search/local/ws/rest/v1";// the namespace you have in the history element
    var xElement = XDocument.Parse(xmlString);
    var history= xElement.Descendants(ns+"History")
                         .Select(historyElement=>new History{ Name = (string)historyElement.Element(ns+"Name"),
                                                              Number = (string)historyElement.Element(ns+"Number"),
                                                              Items = (from e in historyElement.Elements(ns+"Item")
                                                                       select new Item
                                                                              {
                                                                                CraeteDate= DateTime.Parse(e.Element(ns+"CreateDate").Value),
                                                                                Type = (string) e.Element(ns+"Type").Value,
                                                                                Description= string.Join(",",
                                                                                 from p in e.Elements(ns+"Description") select (string)p)
                                                                               }).ToList()
                                                              }).FirstOrDefault();
