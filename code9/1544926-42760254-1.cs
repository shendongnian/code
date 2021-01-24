        public bool Displayed(string elementTagName, string elementAttribute, string value)
        {
                var result = false;
                try
                {
                    var elementDisplayed = ((IJavaScriptExecutor)driver).ExecuteScript($"return $(\"{elementTagName}[{elementAttribute}=\'{value}\']:visible\").length").ToString();
                    result = string.Compare("0", elementDisplayed, StringComparison.OrdinalIgnoreCase) == 0;
                }
                catch (Exception)
                {
                    //ignore exception
                }
                
                return result;
        }
