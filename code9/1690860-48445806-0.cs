    public class MyViewModel : ViewModelBase
    {
        public ObservableCollection<Object> Items { get; }
        public DelegateCommand MenuItemCommand { get; }
        public MyViewModel()
        {
            Items = new ObservableCollection<object>();
            MenuItemCommand = new DelegateCommand(
                () => { /* Do Something */ },
                () => Items.Count > 0);
            Items.CollectionChanged += (s, e) => MenuItemCommand.RaiseCanExecuteChanged();
        }
    }
