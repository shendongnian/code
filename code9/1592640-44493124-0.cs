    private static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
    {
        for (int childCount = 0; childCount < VisualTreeHelper.GetChildrenCount(parent); childCount ++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(parent, childCount);
            if (child != null && child is T)
                return (T)child;
            else
            {
                T childOfChild = FindVisualChild<T>(child);
                if (childOfChild != null)
                    return childOfChild;
            }
        }
        return null;
    }
