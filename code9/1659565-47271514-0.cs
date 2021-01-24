    public static class MakeSure
    {
        private static List<string> errorsFound = new List<string>();
        public static List<string> getErrors() { return errorsFound; }
        public void ElementIsNotNull(IWebElement element, string elementName)
        {
            if(element == null)
            {
               errorsFound.Add("Cannot find element " + elementName +".");
            }
        }
        public void ElementHasAttribute(IWebElement element, string elementName, string attribute)
        {
            if(element.GetAttribute(attribute) == null)
            {
                errorsFound.Add("Cannot find " + attribute + " attribute of the element."); 
            }
        }
        public void ElementContaisText(IWebElement element, string elementName, string attribute, string text)
        {
            if(!element.GetAttribute(attribute).Text.Contains(text))
            {
                errorsFound.Add("Cannot find the text " + text +" in " + elementName +" element"); 
            }
        }
    }
