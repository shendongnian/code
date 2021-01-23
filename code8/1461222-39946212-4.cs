     private ObservableCollection <SubItem> _subItems;
        public ObservableCollection<SubItem> SubItems
        {
            get
            {
                return _subItems;
            }
            set
            {
                _subItems = value;
                OnPropertyChanged("SubItems ");
            }
        }
        public MainViewModel()
        {
            _subItems = new ObservableCollection<SubItem>
            {
                new SubItem{Part1 = "AP1", Part2 = "AP2"},
                new SubItem{Part1 = "BP1", Part2 = "BP2"},
                new SubItem{Part1 = "CP1", Part2 = "CP2"},
            };
        }
