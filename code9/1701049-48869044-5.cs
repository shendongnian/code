    public void viewdata()    
    {
      connection();
      query = "studentEntryView";
      SqlCommand com = new SqlCommand(query, con);
      com.CommandType = CommandType.StoredProcedure;
      com.Parameters.AddWithValue("@Action", HiddenField2.Value).ToString();
      DataSet ds =new DataSet();
      SqlDataAdapter da =  new SqlDataAdapter(com);
      da.Fill(ds);
      GridView1.DataSource = ds;
      GridView1.DataBind();
    }
