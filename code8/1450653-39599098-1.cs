    var attributeEventsDetails =
                    XDocument.Parse(xrmServiceContext.SystemFormSet.FirstOrDefault(form => form.Name == "contact").FormXml)
                        .Descendants("event")
                        .Select(descendants =>
                            new
                            {
                                AttributeName = descendants.Attribute("attribute"),
                                EventName = descendants.Attribute("name"),
                                FunctionName =
                                    descendants.Descendants()
                                        .FirstOrDefault(childDesc => childDesc.Name == "Handler")
                                        .Attribute("functionName")
                            });
