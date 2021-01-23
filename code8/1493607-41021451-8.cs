        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowPoints();
        }
        private void ShowPoints()
        {
            Random random = new Random();
            ObservableCollection<KeyValuePair<double, double>> oc = new ObservableCollection<KeyValuePair<double, double>>();
            for (int i = 1; i <= 1500; i++)
                oc.Add(new KeyValuePair<double, double>(i, random.NextDouble()));
            vm.AddRange(oc);
        }
