    private static T FindVisualChild<T>(
        DependencyObject parent,
        string name = null)
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
                    if (name == null)
                    {
                        return candidate;
                    }
                    FrameworkElement element = candidate as FrameworkElement;
                    if (name == element?.Name)
                    {
                        return candidate;
                    }
                }
                T childOfChild = FindVisualChild<T>(child, name);
                if (childOfChild != null)
                {
                    return childOfChild;
                }
            }
        }
        return default(T);
    }
