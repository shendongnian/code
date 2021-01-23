    public static class UrlHelperExtensions
    {
        public static string MyAction(this UrlHelper urlHelper, string actionName, IList<string> parameters)
        {
            string url = urlHelper.Action(actionName);
            if (parameters == null || !parameters.Any())
            {
                return url;
            }
            return string.Format("{0}?{1}", url, string.Join("&", parameters));
        }
    }
