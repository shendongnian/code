    protected void Chart2_Load(object sender, EventArgs e)
    {
        Chart2.Visible = true;
        /*
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_range";
        cmd.Parameters.AddWithValue("@sub_code", DropDown_Subjects.SelectedItem.Value);
        //  cmd.ExecuteNonQuery();
        connection.Open();
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        */
        Chart2.DataSource = dt;
        Chart2.Series[0].XValueMember = "Score_Achieved";
        Chart2.Series[0].YValueMembers = "No_of_Students";
        Chart2.DataBind();
        Random r = new Random();
        foreach (DataPoint dp in Chart2.Series[0].Points)
            dp.Color = Color.FromArgb(255, r.Next(100, 255), r.Next(100, 255), r.Next(100, 255));
        //connection.Close();
    }
