    var doc = XDocument.Load(file);
                    var characters = doc.Descendants("DocumentElement").FirstOrDefault();
                    if (characters != null)
                    {
                        XElement xe = new XElement("Inventory");
                        characters.Add(xe);
                        var oColl = doc.Descendants("Item");
                        xe.Add(oColl);                   
                    }
                    doc.Save(file);
