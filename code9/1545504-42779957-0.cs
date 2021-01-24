     DataTable dt = new DataTable();
     private void BindGrid()
     {
       string constring = @"Data Source=.\SQL2005;Initial Catalog=Northwind;Integrated Security=true";
       using (SqlConnection con = new SqlConnection(constring))
          {
            using (SqlCommand cmd = new SqlCommand("SELECT CustomerId, ContactName, Country FROM Customers", con))
              {
                 cmd.CommandType = CommandType.Text;
                 con.Open();
                 dt.Load(cmd.ExecuteReader());
                 dataGridView1.DataSource = dt;
                 con.Close();
               }
           }
      }
