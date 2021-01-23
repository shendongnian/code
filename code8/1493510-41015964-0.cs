    public static T FindChild<T>(DependencyObject parent) where T : DependencyObject
        {
            if (parent != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                    if (child != null && child is T)
                    {
                        return (T) child;
                    }
                    T childItem = FindChild<T>(child);
                    if (childItem != null)
                    {
                        return childItem;
                    }
                }
            }
            return null;
        }
