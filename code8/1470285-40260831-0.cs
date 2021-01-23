    public ObservableCollection<Image> Images {get;}
    private void OnImageListChanged(
        object sender
	,   NotifyCollectionChangedEventArgs e) {
        // do something.
    }
    
    public MyForm() {
        Images = new ObservableCollection<Image>();
        Images.CollectionChanged += OnImageListChanged;
    }
