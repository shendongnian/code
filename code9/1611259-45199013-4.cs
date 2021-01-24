    class MainViewModel
    {
        public ObservableCollection<ItemViewModel> Items { get; } =
            new ObservableCollection<ItemViewModel>
            {
                new ItemViewModel { Name = "Item #1" },
                new ItemViewModel { Name = "Item #2" },
                new ItemViewModel { Name = "Item #3" },
            };
        public IReadOnlyList<string> Options { get; } =
            new [] { "Option One", "Option Two", "Option Three" };
        private readonly Dictionary<string, ItemViewModel> _valueToModel =
            new Dictionary<string, ItemViewModel>();
        public MainViewModel()
        {
            foreach (ItemViewModel itemModel in Items)
            {
                itemModel.PropertyChanged += _ItemPropertyChanged;
            }
        }
        private void _ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ItemViewModel.Value))
            {
                ItemViewModel itemModel = (ItemViewModel)sender;
                PropertyChangedExEventArgs<string> exArgs =
                    (PropertyChangedExEventArgs<string>)e;
                if (exArgs.OldValue != null)
                {
                    _valueToModel.Remove(exArgs.OldValue);
                }
                if (itemModel.Value != null)
                {
                    if (_valueToModel.TryGetValue(
                        itemModel.Value, out ItemViewModel otherModel))
                    {
                        otherModel.Value = null;
                    }
                    _valueToModel[itemModel.Value] = itemModel;
                }
            }
        }
    }
