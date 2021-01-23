    XDocument xmlDocument = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XComment("Exporting Users to XML"),
                    new XElement("Users",
                        from usu in db.Users.ToList()
                        select new XElement("User", new XElement("Email", usu.Email),
                                    new XElement("FirstName", usu.FirstName),
                                    new XElement("LastName", usu.LastName),
                                    new XElement("Deleted", usu.LogicalDelete),
                                      from tel in usu.Phones.ToList()
                                      select new XElement("Phone",
                                    new XElement("Phone", tel.Phone),
                                    new XElement("Mobile", tel.Mobile)))
                                ));
                xmlDocument.Save("D:\\user.xml");
