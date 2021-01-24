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
             _mainClassList.Add(new MainClass("Column1","Value1"))
             _mainClassList.Add(new MainClass("Column2","Value2"))
             MainClassList = _mainClassList;
            }
