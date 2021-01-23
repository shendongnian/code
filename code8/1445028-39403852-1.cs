        string updateStatement = "UPDATE Codes SET Manager_Name = @Manager_Name, Created_Date = GETDATE() WHERE Id = @Id AND ProjProjectID = @projectID";
        using (SqlConnection connection = new SqlConnection(ConnectionString())
        using (SqlCommand cmd = new SqlCommand(updateStatement, connection))  {
        connection.Open();
        cmd.Parameters.Add(new SqlParameter("@Manager_Name", textManagerName.Text));
        cmd.Parameters.Add(new SqlParameter("@Created_Date", textDate.Text));
        cmd.Parameters.Add(new SqlParameter("@Id", textID.Text));
        cmd.Parameters.Add(new SqlParameter("@projectID", projProjectID));
        cmd.ExecuteNonQuery();
  
  
