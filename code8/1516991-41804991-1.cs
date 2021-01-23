    ItemsControl itemsControl = ItemsControl_1;
    for (int i = 0; i<itemsControl.Items.Count; i++)
    {
        ContentPresenter cp = itemsControl.ItemContainerGenerator.ContainerFromIndex(i) as ContentPresenter;
        if (cp != null && VisualTreeHelper.GetChildrenCount(cp) > 0)
        {
            Button button = VisualTreeHelper.GetChild(cp, 0) as Button;
            //...
        }
    }
