    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox.Checked) ;
        SqlConnection con = new SqlConnection(@"Data Source=USER-PC\----");
        SqlCommand Cmd = new SqlCommand("select_Info_Person", con);
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.Parameters.AddWithValue("@p1", comboBox1.SelectedValue.ToString());
      //  or if you dont have value feild
      //  Cmd.Parameters.AddWithValue("@p1", comboBox1.Selecteditem.Text.ToString());
        con.Open();
        DataTable dt = new DataTable();
        using (SqlDataAdapter da = new SqlDataAdapter(Cmd))
        {
            da.Fill(dt);
    //I cannot understand what you are doing using below            
    
    // comboBox1.DisplayMember = "Person_Expert";
               // comboBox1.DataSource = dt;
               // con.Close();
            }
        }
