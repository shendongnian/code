    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) 
    {
        dataGridView1.DataSource = null;
        string connectionString = "Define your connection string here";
        using(SqlConnection con = new SqlConnection(connectionString ))
        {
            SqlCommand cmd = new SqlCommand("sp_Expert_person", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@takhasos", SqlDbType.VarChar).Value = comboBox1.SelectedText;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();       
            da.Fill(dt);                   
            this.dataGridView1.Visible = true;
            dataGridView1.DataSource = dt;
        }
    } 
