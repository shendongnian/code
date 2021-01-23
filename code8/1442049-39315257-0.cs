    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("called");
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.ComboBox_SelectionChanged(sender,null);
        }
