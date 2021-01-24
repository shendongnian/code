    var xmlNodes = xElement.Descendants("resource")
                           .Select(e => new
                                        {
                                          ConvertFrom = (string)e.Elements().FistOrDefault(r=>r.Attribute("name").Value=="symbol"),
                                          ConvRate = (string)e.Elements().FistOrDefault(r=>r.Attribute("name").Value=="price"),
                                          ConvDate = (DateTime)e.Elements().FistOrDefault(r=>r.Attribute("name").Value=="utctime"),
                                         });
