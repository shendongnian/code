     XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Server.MapPath("~/employee.xml"));
            XmlElement root = xmlDoc.DocumentElement;       
            string Content = string.Empty;           
            Content += "<div>" + root.Name;
            Content += "<ul>";
            foreach (XmlNode node in root)
            {
                Content += node.Name;
                for (int i = 0; i < node.ChildNodes.Count; i++)
                {
                    Content += "<li>" + (node.ChildNodes[i]).Name + " : " + (node.ChildNodes[i]).InnerText + "</li>";
                }
            }
            Content += "</ul>";
            Content += "</div>";
