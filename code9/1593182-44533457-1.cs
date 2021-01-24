    class MainViewModel : NotifyPropertyChangedBase
    {
        public ObservableCollection<TreeItemViewModel> Items { get; }
            = new ObservableCollection<TreeItemViewModel>();
        public ICommand ClearSelection { get; }
        public MainViewModel()
        {
            ClearSelection = new ClearSelectionCommand(this);
        }
        class ClearSelectionCommand : ICommand
        {
            private readonly MainViewModel _parent;
            public ClearSelectionCommand(MainViewModel parent)
            {
                _parent = parent;
            }
    #pragma warning disable 67
            public event EventHandler CanExecuteChanged;
    #pragma warning restore 67
            public bool CanExecute(object parameter)
            {
                return true;
            }
            public void Execute(object parameter)
            {
                _parent._ClearSelection();
            }
        }
        private void _ClearSelection()
        {
            _ClearSelection(Items);
        }
        private static void _ClearSelection(IEnumerable<TreeItemViewModel> collection)
        {
            foreach (TreeItemViewModel item in collection)
            {
                _ClearSelection(item.Items);
                item.IsSelected = false;
                item.IsExpanded = false;
            }
        }
    }
