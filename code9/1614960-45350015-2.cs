    public static T FindVisualChildByName<T>(FrameworkElement depObj, string name) where T : FrameworkElement
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    var child = VisualTreeHelper.GetChild(depObj, i) as FrameworkElement;
                    if (child != null && child is T && child.Name == name)
                        return (T)child;
                    T childItem = FindVisualChildByName<T>(child, name);
                    if (childItem != null)
                        return childItem;
                }
            }
            return null;
        }
