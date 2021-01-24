    private void table_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            if (((MyData)e.Row.DataContext).Module.Trim().Equals("SomeText"))
            {
                e.Row.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
