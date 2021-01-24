    static class TextHelper
    {
        // You may have to use a different type than `FontStyle` 
        // Hopefully ch.Font has some type of `Style` property you can use
        public static FontStyle CurrentStyle { get; set; }
        public static string OpenTag { get { return GetOpenTag(); } }
        public static string CloseTag { get { return GetCloseTag(); } }
        // This will return the closing tag for the current font style, 
        // followed by the opening tag for the new font style
        public static string ChangeStyleIfNeeded(FontStyle newStyle)
        {
            if (newStyle == CurrentStyle) return string.Empty;
            var transitionStyleTags = GetCloseTag();
            CurrentStyle = newStyle;
            transitionStyleTags += GetOpenTag();
            return transitionStyleTags;
        }
        private static string GetOpenTag()
        {
            switch (CurrentStyle)
            {
                case FontStyle.Bold:
                    return "<b>";
                case FontStyle.Italic:
                    return "<i>";
                case FontStyle.Underline:
                    return "<u>";
                default:
                    return "";
            }
        }
        private static string GetCloseTag()
        {
            switch (CurrentStyle)
            {
                case FontStyle.Bold:
                    return "</b>";
                case FontStyle.Italic:
                    return "</i>";
                case FontStyle.Underline:
                    return "</u>";
                default:
                    return "";
            }
        }
    }
