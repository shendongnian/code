    DataTable myDataTable = new DataTable();
    myDataTable.Columns.Add(new DataColumn("Col1"));
    myDataTable.Columns.Add(new DataColumn("Col2"));
    myDataTable.Rows.Add();
    object[,] matrix = new object[2, 4] {
                                { 0, 0, "line1", "line2" },
                                { 0, 1, "line3", "line4" }, };
    for(int i = 0; i<matrix.GetLength(0); ++i)
    {
        int row = Convert.ToInt32(matrix[i, 0]);
        int column = Convert.ToInt32(matrix[i, 1]);
        myDataTable.Rows[row][column] = matrix[i, 2].ToString() + Environment.NewLine + matrix[i, 3].ToString();
    }
    dataGrid.ItemsSource = myDataTable.DefaultView;
