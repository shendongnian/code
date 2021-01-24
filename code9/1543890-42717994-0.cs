    public MainWindowViewModel()
        {
           
            Items.Add(new ScreenViewModel
            {
                DisplayName = "Screen 1",
                SingletonViewModel = new SingletonViewModel()
            });
            Items.Add(new ScreenViewModel
            {
                DisplayName = "Screen 2",
                SingletonViewModel = new SingletonViewModel()
            });
            ActiveItem = Items.First();
        }
