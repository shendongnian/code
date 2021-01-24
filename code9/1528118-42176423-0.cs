    public static void ScrollToEnd(FlowDocumentScrollViewer fdsv)
    {
        ScrollViewer sc = FindVisualChildren<ScrollViewer>(fdsv).First() as ScrollViewer;
        if (sc != null)
            sc.ScrollToEnd();
    }
    public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
    {
        if (depObj != null)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                if (child != null && child is T)
                {
                    yield return (T)child;
                }
                foreach (T childOfChild in FindVisualChildren<T>(child))
                {
                    yield return childOfChild;
                }
            }
        }
    }
