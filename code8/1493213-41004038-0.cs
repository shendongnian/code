    protected void AddItem()
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["2008DB"].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Connection = conn;
            cmd.CommandText = "select * from items where ID = @lookup";
            cmd.Parameters.Add("@lookup", SqlDbType.NVarChar).Value = txtScan.Text; //You'll also want to fix this line to use the TextBox instead of the Button
            DataTable dtScans = new DataTable(); //Create the new DataTable so you have something to fill
            da.Fill(dtScans);
            GridView1.DataSource = dtScans; //Set the DataTable to be the sourse for a GridView
        }
    }
