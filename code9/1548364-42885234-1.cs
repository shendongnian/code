    SqlConnection connection = new SqlConnection(connectionString);
    connection.Open();
    string query = "UPDATE CAC SET nextMaintainance = @nextMaintainance WHERE department = @department";
    SqlCommand command = new SqlCommand(query, connection);
    command.Parameters.AddWithValue("@department", departmentCb.Text);
    command.Parameters.AddWithValue("@nextMaintainance", nextMaintainanceDT.Value);
    command.ExecuteNonQuery(); 
