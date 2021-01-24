     public MainWindow()
        {
            InitializeComponent();
            CommandBindings.Add(new CommandBinding(ClickCommand, OnClickCommand, OnCanClickCommand));
            var i11 = new Item() { Name = "aaaa aaaa" };
            var i12 = new Item() { Name = "bbbb bbbb" };
            var i21 = new Item() { Name = "cccc cccc" };
            var i22 = new Item() { Name = "dddd dddd" };
            var i0 = new Item() { Name = "I1", Children = new List<Item>() { i11, i12 } };
            var i1 = new Item() { Name = "I1", Children = new List<Item>() { i21, i22 } };
            tv.ItemsSource = new List<Item>() { i0, i1 };
        }
        private void OnCanClickCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void OnClickCommand(object sender, ExecutedRoutedEventArgs e)
        { 
            MessageBox.Show(((Item)e.Parameter).Name);
        } 
        public static RoutedUICommand ClickCommand = new RoutedUICommand("ClickCommand", "ClickCommend", typeof(MainWindow));
