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
            row = Data.NewRow();
           //Add new row and assign values to columns, no need to add columns again and again in loop which will throw exception
        }
