    public static class UILabelExtensionMethod
    {
        public static bool TextIsNullOrEmpty (this UILabel label)
        {
            return string.IsNullOrEmpty (label?.Text);
        }
    }
