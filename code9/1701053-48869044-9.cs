    protected void update(object sender, GridViewUpdateEventArgs e)
    {
      connection();
      int id=int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
      HiddenField1.Value = "update";
      query = "EmpEntry";
      com = new SqlCommand(query, con);
      com.CommandType = CommandType.StoredProcedure;
      com.Parameters.AddWithValue("@Action", HiddenField1.Value).ToString();
      com.Parameters.AddWithValue("@FName", ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text.ToString());
      com.Parameters.AddWithValue("@MName", ((TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0]).Text.ToString());
      com.Parameters.AddWithValue("@LName", ((TextBox)GridView1.Rows[e.RowIndex].Cells[5].Controls[0]).Text.ToString());
      com.Parameters.AddWithValue("@id", SqlDbType.int ).Value = id;
      com.ExecuteNonQuery();
      con.Close();
      GridView1.EditIndex = -1;
      gedata();    
    }
    
