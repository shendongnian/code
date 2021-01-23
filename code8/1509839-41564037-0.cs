    protected void DataEmployees()
    {
      using (SqlConnection con = new SqlConnection(cs))
      {
         con.Open();
         SqlCommand cmd = new SqlCommand
         (
           "Select firstname,lastname FROM employees",con
          );
          SqlDataReader dr = cmd.ExecuteReader();
          DataTable dt = new DataTable();
          dt.Load(dr);
          dataEmployees.DataSource = dt;
       }
     }
