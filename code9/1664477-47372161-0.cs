        // This will hold the urls
        private ObservableCollection<string> urls = new ObservableCollection<string>();
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            // Bind to our collection
            dataGrid.ItemsSource = urls;    
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            // Parse the url from our text and add it to our collection
            urls.Add(GetUrlFromText(textBox.Text));
        }
