    public ObservableCollection<PageView> PageViews
    {
         get { return pageViews; }
         set 
         {
            pageViews = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PageViews)));
         }
    }
