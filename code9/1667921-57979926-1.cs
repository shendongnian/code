    string oradb = "Data Source=ORCL;User Id=hr;Password=hr;";
    OracleConnection conn = new OracleConnection(oradb);
    conn.Open(); 
    OracleCommand cmd = new OracleCommand();
    cmd.UseEdmMapping = true; // # THIS IS WHAT I HAD TO SET TO TRUE #
    cmd.Connection = conn;
    cmd.CommandText = "select department_name from departments where department_id = 10";
    cmd.CommandType = CommandType.Text; 
    OracleDataReader dr = cmd.ExecuteReader();
    dr.Read();
    label1.Text = dr.GetString(0);
    conn.Dispose();
