    protected void delete(object sender, GridViewDeleteEventArgs e)
    {
          connection();
    
          int id =  int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
    
          HiddenField1.Value = "Delete";
    
          query = "EmpEntry";
    
          com = new SqlCommand(query, con);
    
          com.CommandType =CommandType .StoredProcedure;
    
          com.Parameters.AddWithValue("@Action", HiddenField1.Value).ToString();
    
          com.Parameters.AddWithValue("id", SqlDbType.Int).Value = id;
    
          com.ExecuteNonQuery();
    
          con.Close();
    
          gedata();                 
    
     }
     
