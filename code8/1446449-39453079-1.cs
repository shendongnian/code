    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Unity Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public MainWindowViewModel()
        {
            Items = new ObservableCollection<UsageItem>();
            Items.Add(new UsageItem("Bob", 1));
            Items.Add(new UsageItem("Bill", 2));
            Items.Add(new UsageItem("Joe", 3));
            CurrentItem = Items[0];
            UseCommand = new DelegateCommand(Use);
        }
        public ObservableCollection<UsageItem> Items { get; private set; }
        private UsageItem _currentItem;
        public UsageItem CurrentItem
        {
            get { return _currentItem; }
            set { SetProperty(ref _currentItem, value); }
        }
        public DelegateCommand UseCommand { get; private set; }
        private void Use()
        {
            if (CurrentItem.ChargesLeft >= 1)
            {
                CurrentItem.ChargesLeft--;
            }
            else
            {
                //Will remove this UsageItem from my ObservableCollection
                Items.Remove(CurrentItem);
                CurrentItem = Items[0];
            }
        }
    }
