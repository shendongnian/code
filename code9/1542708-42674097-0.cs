    XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            var myEmails = doc.GetElementsByTagName("Email");
            foreach (XmlNode mail in myEmails)
            {
                string mailText = mail.FirstChild.InnerText;
                Response.Write(mailText);
            }
    
