    private async Task ConvertExcel(object sender)
    {
        var excelEngine = new ExcelEngine();
        var application = excelEngine.Excel;
        var newbookWorkbook = application.Workbooks.Create(1);
        var work = newbookWorkbook.Worksheets[0];
        var openDialog = new SaveFileDialog
        {
            FilterIndex = 2,
            Filter = "Excel 97 to 2003 Files(*.xls)|*.xls|Excel 2007 to 2013 Files(*.xlsx)|*.xlsx"
        };
        if (openDialog.ShowDialog() == true)
        {
            newbookWorkbook.Version = openDialog.FilterIndex == 1 ? ExcelVersion.Excel97to2003 : ExcelVersion.Excel2013;
        }
        else
            return;
        try
        {            
             // This method is used to get the data from server.          
             var table = await GetFullDataAsync();
             work.ImportDataTable(table, true, 1, 1, true);
             
             var saveWorkbookTask = Task.Run(() => {
                 using (Stream stream = openDialog.OpenFile())
                 {
                    newbookWorkbook.SaveAs(stream);
                 }
             });
             await saveWorkbookTask;
             newbookWorkbook.Close();
             excelEngine.Dispose();
        }
        catch (Exception exception)
        {
           Console.WriteLine("Exception message: {0}",ex.Message);
        }
    }
    internal async Task<DataTable> GetFullDataAsync()
    {
        DataTable dataTable = new DataTable();
        dataTable = await GetDataFromServer(DataEngine.Query,DataEngine.Connection);
        dataTable.Locale = CultureInfo.InvariantCulture;
        return dataTable;
    }        
    public async Task<DataTable> GetDataFromServer(string query, DbConnection connection)
    {
        if (connection.State != ConnectionState.Open)
        {
            connection.Open();
        }
        var command = connection.CreateCommand();
        command.CommandText = query; 
        command.Connection = connection;
        var reader = await command.ExecuteReaderAsync();
        var loadTableTask = Task.Run(() => {
            var dataTable = new DataTable
            {
                Locale = System.Globalization.CultureInfo.InvariantCulture
            };
            dataTable.Load(reader);
            return dataTable;
        });
        return await loadTableTask;
    }
