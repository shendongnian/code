                XDocument xdoc = new XDocument(new XElement("Text", 
                   Infos.Select(item => new  XElement("Info",
                        new XAttribute("name", item.Name),
                        new XAttribute("language", item.Language),
                        item.Value
                        )
                    )
                ));
