        public static class ExtensionMethods
        {
            public static IHtmlString Translate(this HtmlHelper helper, string text)
            {
                if (string.IsNullOrWhiteSpace(text))
                    return new HtmlString(string.Empty);
                var identity = (WebIdentity)helper.ViewContext.HttpContext.User.Identity;
                return new HtmlString(ResourceController.GetResourceManger(identity.Learner.SystemLanguageId)[text]);
            }
        }
