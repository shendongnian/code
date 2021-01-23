        void DataGridRow_Unselected(object sender, RoutedEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            Task.Factory.StartNew(() =>
            {
                Application.Current.Dispatcher.Invoke(() => { row.IsSelected = true; });
            });
        }
