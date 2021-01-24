    var dt1 = new DataTable();
    var p1 = dt1.Columns.Add("a", typeof(int)); //Use this to add Primary Key constraint
    dt1.Columns.Add("b");
    dt1.Columns.Add("c");
    dt1.Rows.Add("1", "apple", "10");
    dt1.Rows.Add("2", "mango", "20");
    dt1.Rows.Add("3", "orange", "30");
    dt1.Rows.Add("4", "banana", "40");
    dt1.PrimaryKey = new DataColumn[] { p1 }; //This removes duplication of rows
    var dt2 = new DataTable();
    var p2 = dt2.Columns.Add("a", typeof(int)); //Use this to add Primary Key constraint        
    dt2.Columns.Add("b");
    dt2.Columns.Add("d");
    dt2.Rows.Add("1", "apple", "50");
    dt2.Rows.Add("2", "mango", "60");
    dt2.Rows.Add("3", "orange", "70");
    dt2.Rows.Add("5", "grapes", "80");
    dt2.PrimaryKey = new DataColumn[] { p2 }; //This removes duplication of rows
    var dt3 = dt1.Copy();
    dt3.Merge(dt2);  // Merge here merges the values from both provided DataTables
