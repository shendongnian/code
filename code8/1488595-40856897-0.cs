     private DataTable ConvertListToDataTable(List<double[]> list)
            {
                DataTable table = new DataTable();
                WF_CRM_RPluginModel model = DataContext as WF_CRM_RPluginModel;
                // Get max columns.
                int columns = 0;
                foreach (var array in list)
                {
                    if (array.Length > columns)
                    {
                        columns = array.Length;
                    }
                }
    
               // Add columns.
                for (int i = 0; i < columns; i++)
                {
                    // Provide default column name & data type
                    table.Columns.Add(model.injwells[i], typeof(double));
                   
                }
    
                // Add rows.
                foreach (var array in list)
                {
                    // assign each array element to the appropriate column
                    var row = table.NewRow();
                    for (int i = 0; i < array.Length; ++i)
                        row.SetField(i, array[i]);
                    table.Rows.Add(row);
                }
    
     //ADDED below part
                DataColumn newCol = new DataColumn("Prod Name", typeof(string));
                newCol.AllowDBNull = true;
                table.Columns.Add(newCol);
                newCol.SetOrdinal(0);
                int m = 0;
                foreach(DataRow row in table.Rows)
                {
                    row["Prod Name"] = model.prodwells[m];
                    m = m + 1;
                }
    
    
              return table;
            }
