    class MainViewModel
    {
        public ObservableCollection<ItemModelBlah> SomeItemModelBlahs { get; private set; }
        public MainViewModel()
        {
            SomeItemModelBlahs = new ObservableCollection<ItemModelBlah>()
            {
                new ItemModelBlah() { Label = "blah0" },
                new ItemModelBlah() { Label = "blah1", CoolStuff = true },
                new ItemModelBlah() { Label = "blah2" }
            };
        }
    }
