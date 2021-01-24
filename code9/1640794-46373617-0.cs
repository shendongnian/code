        private void GetTableToDataGridView()
        {
            //prgBar_DataGridViewLoading
            DatabaseColumns Obj = new DatabaseColumns();
            String SqlcmdString = @"SELECT invoice, shipment, Project, invoiceDateTB, CreatedDate, typeName, exportedDate, statusName, total, import_status, Time_Completed, ERROR_DESCRIPTION FROM dbo.AllInvoicesInReadyStatus";
            String CountcmdString = @"SELECT count(*) FROM dbo.AllInvoicesInReadyStatus";
            SqlDataReader reader;
            int progress;
            int total;
            using (SqlConnection conn = new SqlConnection(lemars._LeMarsConnectionString))
            {
                reader = null;
                SqlCommand Sqlcmd = new SqlCommand(CountcmdString , conn);
                conn.Open();
                total = (int)Sqlcmd.ExecuteScalar(); //Get the total count.
                Sqlcmd.CommandText = SqlcmdString;
                using(reader = Sqlcmd.ExecuteReader()) //this should be in a using statement
                {
                    while(reader.Read())
                    {
                        object[] row = new object[reader.VisibleFieldCount];
                        reader.GetValues(row);
                        LoadSingleRowInToTable(dt, row); //I leave this to you to write.
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
                        //Only call report progress when the progress value changes.
                        var newProgress = i * 100 / total;
                        if(progress != newProgress)
                        {
                            progress = newProgress;
                            dbWorker.ReportProgress(progress);
                        }
                        //Thread.Sleep(500); 
                    }
                }
            }
        }
