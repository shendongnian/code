    static class DependencyObjectExtensions
    {
        internal static T FindType<T>(this DependencyObject reference) where T : DependencyObject
        {
            int n = VisualTreeHelper.GetChildrenCount(reference);
            for (int i = 0; i < n; i++)
            {
                var c = VisualTreeHelper.GetChild(reference, i) as T;
                if (null != c) return c;
            }
            return null;
        }
    }
