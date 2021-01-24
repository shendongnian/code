    <DataGrid x:Name="dataGrid" ItemsSource="{Binding PartCollection}" AutoGenerateColumns="True" BeginningEdit="dataGrid_BeginningEdit">
        private void dataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            if((e.Row.Item as Part).Manufacturer == "XYZ")
            {
                e.Cancel = true;
            }
        }
