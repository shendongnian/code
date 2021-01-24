            private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (var item in columnList)
            {
                DataGridTextColumn column = new DataGridTextColumn();
                column.Binding = new Binding(item);
                column.Header = UppercaseFirst(item);
                column.IsReadOnly = true;
                dataGridPrivatecustomers.Columns.Add(column);
            }
            DataTable dt = e.Result as DataTable;
            dataGridPrivatecustomers.ItemsSource = dt.DefaultView;
        }
