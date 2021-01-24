    private void bgnWorker_LoadingForm_DoWork(object sender, DoWorkEventArgs e)
        {
            // TODO: query your database
            // for easier reading I assume that your query-result has only one column
            //string query = @"Select * from dbo.AllInvoicesInReadyStatus";
            //** did you strip your sql-execution-code? have a look at https://msdn.microsoft.com/de-de/library/system.data.sqlclient.sqlcommand.aspx
            var queryResult = new List<object>();
            //queryResult.Add(query);
            bgnWorker_LoadingForm.ReportProgress(10);
            var table = new System.Data.DataTable();
            // TODO: create matching columns for your query-result in the datatable
            // https://msdn.microsoft.com/de-de/library/system.data.datatable.newrow(v=vs.110).aspx
            // Create new DataTable and DataSource objects. 
            // Declare DataColumn and DataRow variables.
            DataColumn column;
            DataRow row;
            DataView view;
            // Create new DataColumn, set DataType, ColumnName, and add to DataTable.    
            column = new DataColumn();
            //** you could write just typeof(string) here...
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "invoice";
            table.Columns.Add(column);
            // Create second column. 
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "shipment";
            table.Columns.Add(column);
            // Create second column. 
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Project";
            table.Columns.Add(column);
            // Create second column. 
            column = new DataColumn();
            column.DataType = Type.GetType("System.DateTime");
            column.ColumnName = "invoiceDateTB";
            table.Columns.Add(column);
            // Create second column. 
            column = new DataColumn();
            column.DataType = Type.GetType("System.DateTime");
            column.ColumnName = "CreatedDate";
            table.Columns.Add(column);
            // Create second column. 
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "typeName";
            table.Columns.Add(column);
            // Create second column. 
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "statusName";
            table.Columns.Add(column);
            // Create second column. 
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "total";
            table.Columns.Add(column);
            // Create second column. 
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "import_status";
            table.Columns.Add(column);
            // Create second column. 
            column = new DataColumn();
            column.DataType = Type.GetType("System.DateTime");
            column.ColumnName = "Time_Completed";
            table.Columns.Add(column);
            // Create second column. 
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "ERROR_DESCRIPTION";
            table.Columns.Add(column);
            for (var i = 0; i < queryResult.Count; i++)
            {
                var progress = 10 + (int)((float)i / queryResult.Count) * 90;
                bgnWorker_LoadingForm.ReportProgress(progress);
                row = table.NewRow();
            //** dont know whats going on here
            //** but normally you should iterate your data-reader here and transfer the data of your query result to the created row... like this: https://msdn.microsoft.com/de-de/library/haa3afyz(v=vs.110).aspx
                row["invoice"] = i;
                row["shipment"] = "shipment" + i.ToString();
                row["Project"] = "Project" + i.ToString();
                row["invoiceDateTB"].ToString();
                row["CreatedDate"].ToString(); ;
                row["typeName"] = "typeName" + i.ToString();
                row["statusName"] = "statusName" + i.ToString();
                row["total"].ToString();
                row["import_status"] = "import_status" + i.ToString();
                row["Time_Completed"].ToString(); ;
                row["ERROR_DESCRIPTION"] = "ERROR_DESCRIPTION" + i.ToString();
                table.Rows.Add(row);
                // TODO: add the row data to the table
                // same link as before: https://msdn.microsoft.com/de-de/library/system.data.datatable.newrow(v=vs.110).aspx
            }
            //**begin: move this stuff to worker completed
            // Create a DataView using the DataTable. 
            view = new DataView(table);
            // Set a DataGrid control's DataSource to the DataView.
            dataGridView_ShowAllData.DataSource = view;
            //**end
            e.Result = table;
        }
