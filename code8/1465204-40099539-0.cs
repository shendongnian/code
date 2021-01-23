    XDocument doc = System.Xml.Linq.XDocument.Load(yourXMLFile);
                var ab = doc.Root.Descendants("SINGLE").Descendants("KEY").Descendants("MULTIPLE").Descendants("SINGLE").Select(x => new { values = x.Elements().ToList() }).ToList();
                var newList = ab.Select(y => new
                {
                    values = y.values.Select(z =>
                        new
                        {
                            key = z.Attribute("name").Value,
                            value = z.Elements("VALUE").FirstOrDefault().Value
                        }).ToList()
                }).ToList();
