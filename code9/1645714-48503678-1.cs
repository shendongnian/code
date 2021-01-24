    ObservableCollection<T> selectedItems;
    public ObservableCollection<T> SelectedItems
    {
      get { return selectedItems; }
      set { SetProperty( ref selectedItems, value ); }
    }
