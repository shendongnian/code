    string connectionString = null;
    connectionString = ConfigurationManager.ConnectionStrings["AccessConnectionString"].ConnectionString;
    con.ConnectionString = connectionString;
    string medicinename = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Medicine_name"].Value);
    DateTime Expiry_Date=new DateTime (); 
    con.Open();
    cmd = new OleDbCommand("select Expiry_Date as Expiry_Date from Medicine_Available_Detail where Medicine_Name=@Medicine_Name",con);
    cmd.Parameters.AddWithValue("@Medicine_Name",medicinename);
    OleDbDataReader dr = cmd.ExecuteReader();
    while (dr.Read())
    {
        Expiry_Date = Convert.ToDateTime(dr["Expiry_Date"]);
        
    }
    dataGridView1.Rows[e.RowIndex].Cells["Expiry_Date"].Value = Expiry_Date; 
    con.Close();
