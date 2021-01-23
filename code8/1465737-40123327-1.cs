    private ObservableCollection<Model> Collection = new ObservableCollection<Model>();
    
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        for (int i = 0; i < 50; i++)
        {
            Collection.Add(new Model { Name = "Name " + i + ", ", Age = i });
        }
    }
    
    private void listview_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        foreach (Model item in e.AddedItems)
        {
            item.IsSelected = true;
        }
        foreach (Model item in e.RemovedItems)
        {
            item.IsSelected = false;
        }
    }
    
    public class Model : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public int Age { get; set; }
    
        private bool _IsSelected;
    
        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                if (value != _IsSelected)
                {
                    _IsSelected = value;
                    OnPropertyChanged();
                }
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
