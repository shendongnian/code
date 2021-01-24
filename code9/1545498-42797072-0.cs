    ICollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(chatList.ItemsSource);
    view.GroupDescriptions.Add(new PropertyGroupDescription("Date"));
    ICollectionViewLiveShaping liveView = view as ICollectionViewLiveShaping;
    if(view != null)
    {
        liveView.IsLiveGrouping = true;
        liveView.LiveGroupingProperties.Add("Date");
    }
