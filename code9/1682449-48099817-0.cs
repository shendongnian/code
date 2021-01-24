    int count = VisualTreeHelper.GetChildrenCount(myControl);
    for (int i = 0; i < count; i++)
    {
       DependencyObject current = VisualTreeHelper.GetChild(myControl, i);
       if (current.GetType().Equals(typeof(Grid)))
       {
           ...
       }
    }
