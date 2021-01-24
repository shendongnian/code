     string conn = "Server=EGC25199;Initial Catalog=LegOgSpass;Integrated Security=True";
     string query = "sampleone";
     SqlConnection connDatabase = new SqlConnection(conn);
     connDatabase.Open();
     SqlCommand cmd = new SqlCommand(query, connDatabase);
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@createdOn", SqlDbType.Date).Value = "2017-10-10"; 
     cmd.ExecuteNonQuery();
     connDatabase.Close();
