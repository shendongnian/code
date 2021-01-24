     public MainWindow()
        {
            InitializeComponent();
            var btn1 = new Button{Content = "btn1"};
            //add event handler 1
            btn1.Click += ClickHandler1;
            //removes event handler 1
            btn1.Click -= ClickHandler1;
            //add event handler 2
            btn1.Click += ClickHandler2;
            Panel.Children.Add(btn1);
        }
        private void ClickHandler1(object sender, RoutedEventArgs e)
        {
            //do something
        }
        private void ClickHandler2(object sender, RoutedEventArgs e)
        {
            //do something
        }
        private void ClickHandler3(object sender, RoutedEventArgs e)
        {
            //do something
        }
