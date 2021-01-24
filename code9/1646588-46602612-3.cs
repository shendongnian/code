    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Tab> Tabs { get; } = new ObservableCollection<Tab>();
        public bool AnyTabBusy
        {
            get { return Tabs.Any(t => t.IsBusy); }
        }
        public MainWindowViewModel()
        {
            Tabs.CollectionChanged += TabsCollectionChanged;
        }
        private void TabsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (Tab tab in e.NewItems)
                    {
                        tab.PropertyChanged += TabPropertyChanged;
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (Tab tab in e.OldItems)
                    {
                        tab.PropertyChanged -= TabPropertyChanged;
                    }
                    break;
                default:
                    break;
            }
        }
        private void TabPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Tab.IsBusy))
            {
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(AnyTabBusy)));
            }
        }
    }
