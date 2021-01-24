            private ObservableCollection<MainClass> _mainClassList = new ObservableCollection<MainClass>();
            public ObservableCollection<MainClass> MainClassList
            {
                get { return _mainClassList; }
                set
                {
                    _mainClassList= value;
                    NotifyPropertyChanged(m => m.MainClassList);
                }
            }
            public void AddItems()
            {
             _mainClassList.Add(new MainClass("row1","row1Value"))
             _mainClassList.Add(new MainClass("row2","row2Value"))
             MainClassList = _mainClassList;
            }
