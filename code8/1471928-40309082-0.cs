                string xml =
                    "<Dates>" +
                        "<Department>" +
                         "<ID>Food</ID>" +
                         "<Date>25-11-2016</Date>" +
                        "</Department>" +
                        "<Department>" +
                         "<ID>Sport</ID>" +
                         "<Date>26-10-2016</Date>" +
                        "</Department>" +
                    "</Dates>";
                XElement dates = XElement.Parse(xml);
                List<XElement> departs = dates.Descendants("Department").Where(x => DateTime.ParseExact(x.Element("Date").Value, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture) < DateTime.Now).ToList();
