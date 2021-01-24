    private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DC-POR\\SQLEXPRESS;Initial Catalog=por_test;Integrated Security=True;";
        using(SqlConnection con = new SqlConnection(connectionString))
        {             
            string sql = @"INSERT into tbl_persons (person_id,p_name,p_surname) VALUES (@param1,@param2,@param3)";
           using(var cmd = new SqlCommand())
           {
          cmd.Connection = conn;
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = sql;
          cmd.Parameters.AddWithValue("@param1", 55);  
          cmd.Parameters.AddWithValue("@param2", 'TEST');  
          cmd.Parameters.AddWithValue("@param3", 'test1');
          con.Open();
          cmd.ExecuteNonQuery();
          }
         
          }
        }
