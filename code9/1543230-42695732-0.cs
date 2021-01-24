    public static class XmlString
    {
        public static bool IsFragment(string xml)
        {
            try
            {
                XElement.Parse(xml);
                return false;
            }
            catch
            {
                XElement.Parse("<root>" + xml + "</root>");
                return true;
            }
        }
    }
