    string sql = "SELECT Id, Descr FROM ccolor";
    
    using (MySqlConnection dbcon = new MySqlConnection(MySQLConnStr))
    using (MySqlCommand cmd = new MySqlCommand(sql, dbcon))
    {
        DataTable dt = new DataTable();
        dbcon.Open();
    
        // fill the datatable
        dt.Load(cmd.ExecuteReader());
    
        // set up cbo
        cboColor.DisplayMember = "Descr";
        cboColor.ValueMember = "Id";
        cboColor.DataSource = dt;
    }
