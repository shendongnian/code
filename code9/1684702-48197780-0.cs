    DisplayInfo.DisplayListed.AddRange((from e in xdoc2.Descendants("result")
                                select new DisplacedModelList() {
                                    Name = Convert.ToString(e.Element("name").Value),
                                    Address = (e.Element("formatted_address") != null ? Convert.ToString(e.Element("formatted_address").Value) : null),
                                    Type = keyword,
                                    PhoneNo = (e.Element("international_phone_number") != null ? Convert.ToString(e.Element("international_phone_number").Value) : null),
                                    WebSite = (e.Element("website") != null ? Convert.ToString(e.Element("website").Value) : null),
                                    Rating = (e.Element("rating") != null ? Convert.ToString(e.Element("rating").Value) : null)
                                }).ToList());
