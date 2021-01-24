            // create xml document
            var xmldoc = new XmlDocument();
            // load file
            xmldoc.Load(fullpath);            
            // get all elemtents with name option
            var optionNodes = xmldoc.GetElementsByTagName("option");
            
            // create tabel
            StringBuilder resultHtml  = new StringBuilder("<tabel>");
            // loop all option nodes
            foreach (XmlNode node in optionNodes) { 
                // split current node where ,
                string[] words = node.Value.Split(',');
                // loop words and add them to a row
                resultHtml.Append("<tr>");
                foreach (string word in words)
                {
                    resultHtml.Append( $"<td>{word}</td>");
                }
                resultHtml.Append("</tr>");
            }
            // close tabel
            resultHtml.Append("</tabel>");
