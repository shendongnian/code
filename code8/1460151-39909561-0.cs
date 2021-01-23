    private static List<XAttribute> ParseXmlString(string xmlStr, string searchValue)    
    {
                List<XAttribute> result = new List<XAttribute>();
    
            try
            {
                XDocument doc = XDocument.Parse(xmlStr);
                result = doc.Descendants("directory").Attributes("dirname").Where(x => x.Value.StartsWith("d")).ToList();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
