        [FindsBy(How = How.XPath, Using = "//p[contains(@data-bind, 'invalid')]")]
        private readonly IWebElement _errorMsgAlert = null;
        public string GetAlertError()
        {
            string errmsg= MyFunctions.GetElementText(_errorMsgAlert);
            return errmsg;
        }
        public static string GetElementText(IWebElement element)
        {
            var text = "";
            while (true)
            {
                try { text = element.Text; }
                catch (StaleElementReferenceException) { }
                return text;
            }
        }
