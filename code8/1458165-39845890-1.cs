    MySqlConnection = CDBAccess.GetCon;
    string queryString = "SELECT * from mytable;";
    SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
    DataSet ds = new DataSet();
    adapter.Fill(ds, "mytable");
    DataTable data = ds.Tables[0];
    String path = @"C:\Users\Public\Documents\MyDocument";
    CreateCSVFile(data, path);
