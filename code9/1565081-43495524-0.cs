     XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Server.MapPath("~/car.xml"));
            XmlElement root = xmlDoc.DocumentElement;       
            string Content = string.Empty;           
            Content += "<div>" + root.Name.Replace('_', ' ');
            Content += "<ul>";
            foreach (XmlNode node in root)
            {
                Content += node.Name.Replace('_', ' ');
                for (int i = 0; i < node.ChildNodes.Count; i++)
                {
                    Content += "<li>" + (node.ChildNodes[i]).Name.Replace('_', ' ') + " : " + (node.ChildNodes[i]).InnerText + "</li>";
                }
            }
            Content += "</ul>";
            Content += "</div>";
