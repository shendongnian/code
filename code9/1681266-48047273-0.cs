            string testData = @" <RESPONSE>
                        <DATA id=""1""/>
                        <DATA id = ""2""/> 
                        <DATA id = ""3""/>  
                        <DATA id = ""4""/>   
                    </RESPONSE>";
            
            XDocument xdc = XDocument.Parse(testData);
            var elementes = xdc.Descendants("DATA")
                .Where(e => e.Attribute("id") != null ? e.Attribute("id").Value == "2" : false);
            foreach (XElement element in elementes)
            {
                XAttribute attribute = new XAttribute("value", "200");
                element.Add(attribute);
            }
            var str = xdc.ToString();
