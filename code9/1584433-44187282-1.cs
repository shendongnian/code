    int[] colsToHide = { 0, 4, 5, 6, 7, 8, 10, 11, 12, 13 };
    int pointer = 0;
    //Hide for as long as the desired column index exists
    //Which means the order you put the indices in colsToHide
    //DOES affect the results of the while loop.
    while (colsToHide[pointer] < InvoiceProductsDataGrid.Columns.Count)
    {
        InvoiceProductsDataGrid.Columns[colsToHide[pointer]].Visibility = Visibility.Hidden;
    }
