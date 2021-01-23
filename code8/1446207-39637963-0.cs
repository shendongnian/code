     DropDownList1.Items.Clear();
     DataTable dt = new DataTable();
     ExcelPackage package = new ExcelPackage(FileUpload1.FileContent);
     dt = package.ToDataTable(); //Datatable data from excel file
     for (int i = 0; i < dt.Columns.Count; i++)
     {
        //Now depending on whether you will have to access them by value or not:
        DropDownList1.Items.Add(new ListItem(dt.Columns[i].ColumnName));    //Without Value
        DropDownList1.Items.Add(new ListItem(dt.Columns[i].ColumnName, i)); //With a numeric value that will serve like an index
     }
