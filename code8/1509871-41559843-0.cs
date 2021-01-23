    public readonly ObservableCollection<string> Collection1 =
            new ObservableCollection<string>();
    public readonly ObservableCollection<string> Collection2 =
            new ObservableCollection<string>();
    public ViewModel() {
        Collection1.CollectionChanged += (sender, args) =>
        {
            Collection2.Clear();
            foreach (var x in Collection1) {
                Collection2.Add(x);
            }
        };
    }
