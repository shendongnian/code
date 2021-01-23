        Dictionary<DataGridColumn, double> columns = new Dictionary<DataGridColumn, double>();
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Dgrd.FontSize = 20;
            columns.Clear();
            foreach (DataGridColumn col in Dgrd.Columns)
            {
                columns.Add(col, col.ActualWidth);
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Dgrd.FontSize = 8;            
            foreach (DataGridColumn col in Dgrd.Columns)
            {
                col.Width = columns[col];
            }
        }
