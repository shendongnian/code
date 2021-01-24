    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
        }
        public Command PickCommand => new Command(() => this.BtnClick());
    
        private async void BtnClick()
        {
            StorageFolder Selectfolder = ApplicationData.Current.LocalFolder;
            this.Items = await FolderService.GetItems(Selectfolder);
        }
        private ObservableCollection<Item> _items;
    
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }
    }
