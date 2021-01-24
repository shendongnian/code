    SqlConnection con = new SqlConnection(connectionString);
    con.Open();
    SqlCommand cmd = new SqlCommand("select TABLE_NAME from DBNAME.TABLES");
    Console.WriteLine(cmd);
    string SelectQuery = "SELECT * FROM dbo.DBNAME";
    SqlCommand a = new SqlCommand(SelectQuery, con);
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    DataTable dtTables = new DataTable();
    da.Fill(dtTables);
    for (int i = 0; i <= dtTables.Rows.Count - 1; i++)
    {
        Console.WriteLine(dtTables.Rows[i][0]);
    }    
