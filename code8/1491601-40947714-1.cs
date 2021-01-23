    DataTable myDataTable = new DataTable("HackTable");
    myDataTable.Columns.Add("Id");
    myDataTable.Columns.Add("Name");
    myDataTable.Columns.Add("Address");
    dsT.Tables[0].Columns.Add("Hack").DefaultValue = 9999; //<-here
    myDataTable.Rows.Add(1, "Rahul", "Parel");
    myDataTable.Rows.Add(2, "Ramesh", "Dadar");
    myDataTable.Rows.Add(3, "Ravi", "Andheri");
    DataSet dsT = new DataSet();
    dsT.Tables.Add(myDataTable);
