    public static class TabItemExtensions
    {
        public static void SetMyProp(TabItem element, string value)
        {
            element.SetValue(MyPropProperty, value);
        }
        public static string GetMyProp(TabItem element)
        {
            return (string)element.GetValue(MyPropProperty);
        }
        public static readonly DependencyProperty MyPropProperty
            = DependencyProperty.RegisterAttached(
                "MyProp",
                typeof(string),
                typeof(TabItem),
                new PropertyMetadata(null)
            );
    }
