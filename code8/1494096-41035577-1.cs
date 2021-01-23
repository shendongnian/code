                   Infos.Select(item => new XElement("Info",
                        new XAttribute("name", item.Name),
                        new XAttribute("language", item.Language),
                        item.Value
                        )
                    )
                ));
                //Option 2
                XDocument xdoc2 = new XDocument();
                xdoc.Add(new XElement("Text", new object[] {
                   Infos.Select(item => new XElement("Info", new object[] {
                        new XAttribute("name", item.Name),
                        new XAttribute("language", item.Language),
                        item.Value
                   }))
                }));
