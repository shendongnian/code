     public MainWindow()
        {
            InitializeComponent();
            
            var button = new Button() {Content = "myButton"}; // Creating button
            button.Click += Button_Click; //Hooking up to event
             myGrid.Children.Add(button); //Adding to grid or other parent
        }
        private void Button_Click(object sender, RoutedEventArgs e) //Event which will be triggerd on click of ya button
        {
            throw new NotImplementedException();
        }
