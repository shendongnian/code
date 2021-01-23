    sql = "select * from myTable";
    ds = new System.Data.DataSet();
    OleDbDataAdapter adp = new OleDbDataAdapter();
    adp.SelectCommand = new OleDbCommand(sql, dbConnection._connection);
    OleDbCommandBuilder cb = new OleDbCommandBuilder(adp);
    adp.Fill(ds);
    ds.AcceptChanges();
    grdTable.ItemsSource = ds.Tables[0].DefaultView;
