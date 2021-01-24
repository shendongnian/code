    public class LocalizationAttribute : ActionFilterAttribute
    {
        private readonly string _defaultLanguage = "en-US";
        public LocalizationAttribute(string defaultLanguage = null)
        {
            this._defaultLanguage = defaultLanguage ?? this._defaultLanguage;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var language = filterContext.RouteData.Values["language"] as string ?? this._defaultLanguage;
            if (language != this._defaultLanguage)
            {
                try
                {
                    Thread.CurrentThread.CurrentCulture =
                        Thread.CurrentThread.CurrentUICulture =
                            CultureInfo.CreateSpecificCulture(language);
                }
                catch
                {
                    throw new NotSupportedException($"Invalid language code '{language}'.");
                }
            }
        }
    }
