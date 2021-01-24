                List<XElement> users = document.Descendants("Users")
                    .Where(user => user.Elements("Identification")
                  .Where(el => (string)el.Attribute("IDValue") != myID)
                  .Any()).ToList();
                
               XElement element1 = document.Descendants("Element1").FirstOrDefault();
               element1.ReplaceNodes(users);
