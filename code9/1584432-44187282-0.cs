    int[] colsToHide = { 0, 4, 5, 6, 7, 8, 10, 11, 12, 13 };
    int pointer = 0;
    while (colsToHide[pointer] < InvoiceProductsDataGrid.Columns.Count)
    {
        InvoiceProductsDataGrid.Columns[colsToHide[pointer]].Visibility = Visibility.Hidden;
    }
