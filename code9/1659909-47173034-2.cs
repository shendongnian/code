    SqlCommand cmd2 = con.CreateCommand();
    cmd2.CommandType = CommandType.Text;
    cmd2.CommandText = "Select Pid From Provinces where Pname=@pr";
    cmd2.Parameters.Add(new SqlParameter("pr", pr));
    SqlConnection Connection = new SqlConnection(ConnectionString);
    SqlDataAdapter adp = new SqlDataAdapter(cmd2);
    // Create a new datatable which will hold the query results:
    DataTable dt = new DataTable();
    Connection.Open();
    // Fill a datatable with the query results:
    adp.Fill(dt);
    Connection.Close();
