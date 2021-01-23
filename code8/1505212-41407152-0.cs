     private static int ParseErrorIdField(string xml)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            var errorIdField = xmlDoc.SelectSingleNode("//*[contains(name(),'errorID')]");
            if (errorIdField == null)
            {
                //couldn't find field in xml
                //return parsing error
                return -1;
            }
            int errorId;
            if (!int.TryParse(errorIdField.InnerText, out errorId))
            {
                //Could not convert field to integer
                //raise error
                return -1;
            }
            return errorId;
        }
