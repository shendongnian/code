    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<ItemViewModel> _title;
        public ObservableCollection<ItemViewModel> Title
        {
            get { return _title; }
            set { SetField(ref _title, value); }
        }
        public MainViewModel()
        {
            var query = Enumerable.Range(0, 10)
                             .Select(o => new ItemViewModel
                             {
                                 Title = $"I am item no. {o}"
                             });
            Title = new ObservableCollection<ItemViewModel>(query);
        }
        private ItemViewModel _selectedItem;
        public ItemViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    if (_selectedItem != null) _selectedItem.IsVisible = false;
                    value.IsVisible = true;
                    _selectedItem = value;
                    OnPropertyChanged();
                }
            }
        }
    }
