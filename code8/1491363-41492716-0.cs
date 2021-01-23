    public static class HtmlUtils
    {
        public static bool IsHtmlFragment(string value)
        {
            return Regex.IsMatch(value, @"</?(p|div)>");
        }
        /// <summary>
        /// Remove tags from a html string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RemoveTags(string value)
        {
            if (value != null)
            {
                value = CleanHtmlComments(value);
                value = CleanHtmlBehaviour(value);
                value = Regex.Replace(value, @"</[^>]+?>", " ");
                value = Regex.Replace(value, @"<[^>]+?>", "");
                value = value.Trim();
            }
            return value;
        }
        /// <summary>
        /// Clean script and styles html tags and content
        /// </summary>
        /// <returns></returns>
        public static string CleanHtmlBehaviour(string value)
        {
            value = Regex.Replace(value, "(<style.+?</style>)|(<script.+?</script>)", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            return value;
        }
        /// <summary>
        /// Replace the html commens (also html ifs of msword).
        /// </summary>
        public static string CleanHtmlComments(string value)
        {
            //Remove disallowed html tags.
            value = Regex.Replace(value, "<!--.+?-->", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            return value;
        }
        /// <summary>
        /// Adds rel=nofollow to html anchors
        /// </summary>
        public static string HtmlLinkAddNoFollow(string value)
        {
            return Regex.Replace(value, "<a[^>]+href=\"?'?(?!#[\\w-]+)([^'\">]+)\"?'?[^>]*>(.*?)</a>", "<a href=\"$1\" rel=\"nofollow\" target=\"_blank\">$2</a>", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }
    }
