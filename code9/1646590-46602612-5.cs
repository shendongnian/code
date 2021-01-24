    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableItemCollection<Tab> Tabs { get; }
            = new ObservableItemCollection<Tab>();
        public bool AnyTabBusy
        {
            get { return Tabs.Any(t => t.IsBusy); }
        }
        public MainWindowViewModel()
        {
            Tabs.ItemPropertyChanged += TabPropertyChanged;
        }
        private void TabPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Tab.IsBusy))
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AnyTabBusy)));
            }
        }
    }
