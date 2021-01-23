        public MainWindow()
        {
            InitializeComponent();
            textBlock.Visibility = Visibility.Collapsed;
            option1.Checked += Option_Checked;
            option2.Checked += Option_Checked;
            option3.Checked += Option_Checked;
            option4.Checked += Option_Checked;
        }
        private void Option_Checked(object sender, RoutedEventArgs e)
        {
            var option = (sender as RadioButton);
            if (option.Name == "option1" || option.Name == "option2")
                textBlock.Visibility = Visibility.Collapsed;
            else
                textBlock.Visibility = Visibility.Visible;
        }
