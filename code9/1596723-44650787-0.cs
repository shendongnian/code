    private void DataGridCamiao_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        DataGrid DataGridCamiao = sender as DataGrid;
        if (DataGridCamiao.SelectedItem != null)
        {
            var item = DataGridCamiao.SelectedItem as YourEntityClass;
            if (item != null)
                TextBoxMarca.Text = item.Marca;
        }
    }
