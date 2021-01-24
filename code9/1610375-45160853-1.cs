           //Prepare Datatable and Add All Columns Here
            dataTable = new DataTable();
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Machine Number";
            column.ReadOnly = false;
            column.Unique = true;
            column.AutoIncrement = false;
       //Excel Input and Dex File Data Marriage
        foreach (string Line in ExcelLines)
        {
         //Add new row and assign values to columns, no need to add columns again and again in loop which will throw exception
         row = dataTable.NewRow();
         //Map all the values in the columns
         row["ColumnName"]= value;
         //At the end just add that row in datatable
         dataTable.Rows.Add(row );
          }
