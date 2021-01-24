    public class ExtendedListViewItem : ListViewItem
    {
        public ExtendedListViewItem()
        {
            // This could be set in its default style in Generic.xaml instead.
            HorizontalContentAlignment = HorizontalAlignment.Stretch;
    
            RegisterPropertyChangedCallback(IsSelectedProperty, (s, e) =>
            {
                // Children() is available at
                // https://github.com/JustinXinLiu/Continuity/blob/0cc3d7556c747a060d40bae089b80eb845da84fa/Continuity/Extensions/UtilExtensions.cs#L25
                foreach (var child in this.Children())
                {
                    if (GetIsExpandable(child))
                    {
                        child.Visibility = IsSelected ? Visibility.Visible : Visibility.Collapsed;
                    }
                }
            });
        }
    
        public static void SetIsExpandable(DependencyObject element, bool value) =>
            element.SetValue(IsExpandableProperty, value);
        public static bool GetIsExpandable(DependencyObject element) =>
            (bool)element.GetValue(IsExpandableProperty);
        public static readonly DependencyProperty IsExpandableProperty = DependencyProperty.RegisterAttached(
            "IsExpandable",
            typeof(bool),
            typeof(ExtendedListViewItem),
            new PropertyMetadata(default(bool), (s, e) =>
                {
                    var element = (UIElement)s;
                    element.Visibility = (bool)e.NewValue ? Visibility.Collapsed : Visibility.Visible;
                }));
    }
