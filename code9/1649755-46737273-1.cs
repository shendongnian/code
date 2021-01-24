    XmlDocument xmlDoc = new XmlDocument();
            string filePath = Path.Combine(@"C:\assets\" + "users.xml");
            XmlNode usersNode;
            if (File.Exists(filePath))
            {
                xmlDoc.Load(filePath);
                usersNode = xmlDoc.SelectSingleNode(@"Users");
            }
            else
            {
                usersNode = xmlDoc.CreateElement("Users");
                xmlDoc.AppendChild(usersNode);
            }
            
            XmlElement user = xmlDoc.CreateElement("User");
            XmlElement userName = xmlDoc.CreateElement("UserName");
            XmlElement pass = xmlDoc.CreateElement("Pass");
            userName.InnerText = "TestUser";
            pass.InnerText = "TemPass";
            user.AppendChild(userName);
            user.AppendChild(pass);
            usersNode.AppendChild(user);
                
            xmlDoc.Save(filePath);
