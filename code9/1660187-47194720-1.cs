    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        var col = new DataGridTemplateColumn
        {
            Header = "Shift",
            CellTemplate = (DataTemplate)FindResource("SPI_Template")
        };
        grdSch.Columns.Add(col);
        for (int i = 0; i < 30; i++)
        {
            col = new DataGridBoundColumn
            {
                Header = "Employee " + (i + 1),
                Binding = new Binding($"data[{i}]"),
                Width = 100,
                CellTemplate = (DataTemplate)FindResource("SEI_Template"),
            };
            grdSch.Columns.Add(col);
        }
    }
