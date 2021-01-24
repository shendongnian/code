    static class GlobalProperties
    {
        private static ObservableCollection<string> _mylist = new ObservableCollection<string>();
        public static ObservableCollection<string> MyList
        {
            get
            {
                return _mylist;
            }
            set
            {
                if (_mylist == value) return; // suggested on comment. Relocate if you still need to run GotUpdated()
                _mylist = value;
                GotUpdated();
                _mylist.CollectionChanged += (sender, e) => GotUpdated();
            }
        }
        
        public static Action GotUpdated { private get; set; }
    }
