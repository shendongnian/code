            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            var accept = doc.SelectSingleNode("//string[@name='accept']").InnerText;
            var actionSettings = doc.SelectSingleNode("//string[@name='action_settings']").InnerText;
            var appName = doc.SelectSingleNode("//string[@name='app_name']").InnerText;
