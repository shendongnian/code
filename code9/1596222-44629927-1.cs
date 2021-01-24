    namespace System.Web.Mvc.Html
    {
        public static class MyHtmlHelper
        {
            public static string DoubleToFormattedLong(this HtmlHelper html, double myValue)
            {
                var longValue = Convert.ToInt64(myValue);
                return string.Format("{0:n0}", longValue);
            }
        }
    }
