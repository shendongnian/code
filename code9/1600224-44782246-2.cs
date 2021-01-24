    private void DirectoryItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
        {
            foreach (object item in e.NewItems)
            {
                (item as INotifyPropertyChanged).PropertyChanged
                    += new PropertyChangedEventHandler(Item_PropertyChanged);
            }
        }
        if (e.OldItems != null)
        {
            foreach (object item in e.OldItems)
            {
                (item as INotifyPropertyChanged).PropertyChanged
                    -= new PropertyChangedEventHandler(Item_PropertyChanged);
            }
        }
    }
