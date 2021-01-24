        private ObservableCollection<string> _Items = new ObservableCollection<string> { "A","B", "C"};
        public ObservableCollection<string> Items
        {
            get
            {
                return _Items;
            }
            set
            {
                if (value == _Items)
                { return; }
                _Items = value;
                RaisePropertyChanged(nameof(Items));
            }
        }
