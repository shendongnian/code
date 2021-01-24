    namespace DynamicViewExample
    {
        class MainWindowVm : ViewModel
        {
            public MainWindowVm()
            {
                Fields = new ObservableCollection<SearchFieldInfo>();
                SearchableTypes = new ObservableCollection<Type>()
                                  {
                                      typeof(Models.User),
                                      typeof(Models.Widget)
                                  };
    
                SearchType = SearchableTypes.First();
            }
    
            public ObservableCollection<Type> SearchableTypes { get; }
            public ObservableCollection<SearchFieldInfo> Fields { get; }
    
    
            private Type _searchType;
    
            public Type SearchType
            {
                get { return _searchType; }
                set
                {
                    _searchType = value;
                    Fields.Clear();
                    foreach (PropertyInfo prop in _searchType.GetProperties())
                    {
                        var searchField = new SearchFieldInfo(prop.Name);
                        Fields.Add(searchField);
                    }
                }
            }
    
            private ICommand _searchCommand;
    
            public ICommand SearchCommand
            {
                get { return _searchCommand ?? (_searchCommand = new SimpleCommand((obj) =>
                {
                    WindowManager.ShowMessage(String.Join(", ", Fields.Select(f => $"{f.Name}: {f.Value}")));
                })); }
            }
        }
    }
