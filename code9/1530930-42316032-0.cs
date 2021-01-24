     public enum ButtonType { button = 0, submit = 1, reset = 2 }
    
     public static class HtmlHelperExtensions
     {
        public static MvcHtmlString Button(this HtmlHelper helper, ButtonType type, string textValue, string id)
        {
                   string buttonTagText = $"<input type=\"{type.ToString()}\" value=\"{textValue}\" id = \"{id}\" />";
                   return MvcHtmlString.Create(buttonTagText);
        }
     }
