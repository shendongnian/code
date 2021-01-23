    SqlCommand cmd = new SqlCommand("your SP_Name", con);
    cmd.CommandType = CommandType.StoredProcedure;
    
    cmd.Parameters.Add(new SqlParameter("param name", "param value"));
    cmd.Parameters.Add(new SqlParameter("param2 name", "param2 value"));
    .
    .
    .
    con.Open();
    SqlDataReader reader = cmd.ExecuteReader();
    con.Close();
    
    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    DataTable dt = new DataTable();
    adapter.Fill(dt);
    
    return dt;
