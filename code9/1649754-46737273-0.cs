    XmlDocument xmlDoc = new XmlDocument();
                string filePath = Path.Combine(@"C:\assets\" + "users.xml");
    
                if (!File.Exists(filePath))
                {
                    XmlElement users = xmlDoc.CreateElement("Users");
                    XmlElement user = xmlDoc.CreateElement("User");
                    XmlElement userName = xmlDoc.CreateElement("UserName");
                    XmlElement pass = xmlDoc.CreateElement("Pass");
    
                    userName.InnerText = "TestUser";
                    pass.InnerText = "TemPass";
    
                    user.AppendChild(userName);
                    user.AppendChild(pass);
                    users.AppendChild(user);
                    xmlDoc.AppendChild(users);
    
                    xmlDoc.Save(filePath);
                    
                }
                else
                {
                    xmlDoc.Load(filePath);
    
                    XmlNode node = xmlDoc.SelectSingleNode(@"Users");
    
                    XmlElement user = xmlDoc.CreateElement("User");
                    XmlElement userName = xmlDoc.CreateElement("UserName");
                    XmlElement pass = xmlDoc.CreateElement("Pass");
    
                    userName.InnerText = "TestUser2";
                    pass.InnerText = "TemPass2";
    
                    user.AppendChild(userName);
                    user.AppendChild(pass);
                    node.AppendChild(user);
    
                    xmlDoc.Save(filePath);
                }
