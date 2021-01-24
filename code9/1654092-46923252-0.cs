    public class GridViewColumnAttachedProperties
    {
        public static readonly DependencyProperty SortPropertyNameProperty = DependencyProperty.RegisterAttached(
            "SortPropertyName", typeof(string), typeof(GridViewColumnAttachedProperties), new PropertyMetadata(default(string)));
    
        public static void SetSortPropertyName(DependencyObject element, string value)
        {
            element.SetValue(SortPropertyNameProperty, value);
        }
    
        public static string GetSortPropertyName(DependencyObject element)
        {
            return (string) element.GetValue(SortPropertyNameProperty);
        }
    }
