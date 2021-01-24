    public static class Localization
    {
        private class HtmlString : IHtmlString
        {
            private string Value;
            public HtmlString(string value)
            {
                Value = value;
            }
            public string ToHtmlString()
            {
                return Value;
            }
        }
        public static IHtmlString Message(string key)
        {
            return new HtmlString(localizationService.GetMessage(key));
        }
    }
