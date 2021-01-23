    SqlConnection sqlConnection = new SqlConnection("Connection String");
    SqlCommand cmd = new SqlCommand();
    SqlDataReader reader;
    cmd.CommandText = "SELECT * FROM Table";
    cmd.CommandType = CommandType.Text;
    cmd.Connection = sqlConnection;
    sqlConnection.Open();
    reader = cmd.ExecuteReader();
    sqlConnection.Close();
