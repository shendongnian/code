    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openfile = new OpenFileDialog();
        openfile.DefaultExt = ".xlsx";
        openfile.Filter = "(.xlsx)|*.xlsx";
    
        var browsefile = openfile.ShowDialog();
    
        if (browsefile == true)
        {
            txtFilePath.Text = openfile.FileName;
    
            DataTable dataTable = await ParseExcel(txtFilePath.Text).ConfigureAwait(true);
    
            dtGrid.ItemsSource = dataTable.DefaultView;
        }
    }
    private Task<DataTable> ParseExcel(string filePath)
    {
        return Task.Run(() =>
        {
            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            var excelBook = excelApp.Workbooks.Open(filePath, 0, true, 5, "", "", true,
                Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            var excelSheet = (Microsoft.Office.Interop.Excel.Worksheet) excelBook.Worksheets.Item[1];
    
            Microsoft.Office.Interop.Excel.Range excelRange = excelSheet.UsedRange;
    
            DataTable dt = new DataTable();
    
            object[,] value = excelRange.Value;
    
            int columnsCount = value.GetLength(1);
            for (var colCnt = 1; colCnt <= columnsCount; colCnt++)
            {
                dt.Columns.Add((string) value[1, colCnt], typeof(string));
            }
    
            int rowsCount = value.GetLength(0);
            for (var rowCnt = 2; rowCnt <= rowsCount; rowCnt++)
            {
                var dataRow = dt.NewRow();
                for (var colCnt = 1; colCnt <= columnsCount; colCnt++)
                {
                    dataRow[colCnt - 1] = value[rowCnt, colCnt];
                }
                dt.Rows.Add(dataRow);
            }
    
            excelBook.Close(true);
            excelApp.Quit();
    
            return dt;
        });
    }
