    void BackgroundAlternatingListView_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
    {
        if (args.ItemIndex % 2 != 0)
        {
            args.ItemContainer.Background = new SolidColorBrush(_secondColor);
        }
        else
        {
            args.ItemContainer.Background = new SolidColorBrush(_startColor);
        }
    }
