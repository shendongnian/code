    public static RadioButton FindRadioButtonWithDataContext(
        DependencyObject parent,
        Data data)
    {
        if (parent != null)
        {
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                ListViewItem lv = child as ListViewItem;
                if (lv != null)
                {
                    RadioButton rb = FindVisualChild<RadioButton>(child);
                    if (rb != null && rb.DataContext == data)
                    {
                        return rb;
                    }
                }
                RadioButton childOfChild = FindRadioButtonWithDataContext(child, data);
                if (childOfChild != null)
                {
                    return childOfChild;
                }
            }
        }
        return null;
    }
