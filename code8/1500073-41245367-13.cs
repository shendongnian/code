    public static T FindVisualChild<T>(
        DependencyObject parent)
        where T : DependencyObject
    {
        if (parent != null)
        {
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                T candidate = child as T;
                if (candidate != null)
                {
                    return candidate;
                }
                T childOfChild = FindVisualChild<T>(child);
                if (childOfChild != null)
                {
                    return childOfChild;
                }
            }
        }
        return default(T);
    }
