                string responseXml = "<Response>" +
                                   "<Result>" +
                                     "<Item1>GREEN</Item1>" +
                                     "<Item2>05/19/2017 22:08:14</Item2>" +
                                   "</Result>" +
                                   "<Other>" +
                                     "<Id>xxxxxxxxxxxxc</Id>" +
                                   "</Other>" +
                                 "</Response>";
                XElement doc = XElement.Parse(responseXml);
                var results = from p in
                                  doc.Descendants("Result")
                              select new
                              {
                                  item = p.Element("Item1").Value,
                              };
                foreach (var elm in results)
                {
                    Console.WriteLine(elm.item);
                }
