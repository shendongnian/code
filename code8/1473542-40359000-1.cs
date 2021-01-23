    private void InitializeDataTable()
    {
        System.Data.DataTable DataTable = new System.Data.DataTable
        {
            Columns = {"Test #", "Img", "Min Range", "Max Range", "Result"}
        };
        Uri uri = new Uri(@"C:/Users/User/Desktop/szagdoga/error.png");
        for (int i = 6; i < 50; i++)
            DataTable.Rows.Add(ExcelFile[0, i], uri, ExcelFile[1, i], 0, 0);
        ChannelDataGrid.ItemsSource = DataTable.DefaultView;
    }
    private void ChannelDataGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.PropertyName == "Img")
        {
            // replace text column with image column
            e.Column = new DataGridTemplateColumn
            {
                // searching for predefined tenplate in Resources
                CellTemplate = (sender as DataGrid).Resources["ImgCell"] as DataTemplate,
                HeaderTemplate = e.Column.HeaderTemplate,
                Header = e.Column.Header
            };
        }
    }
