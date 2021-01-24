    private void dbWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        List<DatabaseColumns> data = GetTableToList();
        if (data == null) //data will be null if we canceled.
        {
            e.Cancel = true;
        }
        else
        {
            e.Result = data;
        }
        dbWorker.ReportProgress(100);
    }
    private void dbWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Cancelled)
        {
            MessageBox.Show("Process Cancelled.");
        }
        else if (e.Error != null)
        {
            MessageBox.Show("Error occurred: " + e.Error.Message);
        }
        else
        {
            dataGridView_ShowAllData.DataSource = e.Result; //use the result from thebackground worker, only use if not canceled or errored.
            MessageBox.Show("Successful Completion.");
        }
        //progressBar_GetTasks.Value = 0;
    }
    private List<DatabaseColumns> GetTableToList()
    {
        List<DatabaseColumns> data = new List<DatabaseColumns>();
        //prgBar_DataGridViewLoading
        String SqlcmdString = @"SELECT invoice, shipment, Project, invoiceDateTB, CreatedDate, typeName, exportedDate, statusName, total, import_status, Time_Completed, ERROR_DESCRIPTION FROM dbo.AllInvoicesInReadyStatus";
        String CountcmdString = @"SELECT count(*) FROM dbo.AllInvoicesInReadyStatus";
        using (SqlConnection conn = new SqlConnection(lemars._LeMarsConnectionString))
        {
            SqlCommand Sqlcmd = new SqlCommand(CountcmdString, conn);
            conn.Open();
            var total = (int)Sqlcmd.ExecuteScalar();
            Sqlcmd.CommandText = SqlcmdString;
            int i = 0;
            int progress = 0;
            using (SqlDataReader reader = Sqlcmd.ExecuteReader()) //this should be in a using statement
            {
                while (reader.Read())
                {
                    if (dbWorker.CancellationPending)
                    {
                        //Exit early if operation was canceled.
                        return null;
                    }
                    DatabaseColumns Obj = new DatabaseColumns();
                    //You can just read directly from the reader.
                    Obj.Invoice = reader["invoice"].ToString();
                    Obj.Shipment = reader["shipment"].ToString();
                    Obj.Project = reader["Project"].ToString();
                    Obj.InvoiceDateTB = Convert.ToDateTime(reader["invoiceDateTB"]);
                    Obj.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    Obj.TypeName = reader["typeName"].ToString();
                    Obj.ExportedDate = Convert.ToDateTime(reader["exportedDate"]);
                    Obj.StatusName = reader["statusName"].ToString();
                    Obj.Total = Convert.ToDecimal(reader["total"]);
                    Obj.ImportStatus = reader["import_status"].ToString();
                    if (!Convert.IsDBNull(reader["Time_Completed"]))
                    {
                        Obj.TimeCompleted = Convert.ToDateTime(reader["Time_Completed"]);
                    }
                    Obj.ErrorDescription = reader["ERROR_DESCRIPTION"].ToString();
                    //Add the object to the list.
                    data.Add(Obj);
                    //Only call report progress when the progress value changes.
                    var newProgress = i * 100 / total;
                    if (progress != newProgress)
                    {
                        progress = newProgress;
                        dbWorker.ReportProgress(progress);
                    }
                    i++;
                }
            }
        }
        return data;
    }
