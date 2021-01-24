        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var dataGridRow = FindChild(dataGrid, x =>
            {
                var element = x as DataGridRow;
                if (element != null && element.Item == System.Windows.Data.CollectionView.NewItemPlaceholder)
                    return true;
                else
                    return false;
            }) as DataGridRow;
            var combo = FindChild(dataGridRow, x =>
            {
                return x is ComboBox;
            }) as ComboBox;
            combo.IsEnabled = false;
        }
