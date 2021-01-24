    public static class PopupWindowProperties
    {
        public static readonly DependencyProperty TitleProperty = DependencyProperty.RegisterAttached("Title", typeof(string), typeof(PopupWindowProperties), new FrameworkPropertyMetadata(string.Empty));
        public static void SetTitle(UIElement element, string value) => element.SetValue(TitleProperty, value);
        public static string GetTitle(UIElement element) => element.GetValue(TitleProperty) as string;
    }
