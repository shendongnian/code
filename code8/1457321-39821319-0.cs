    qlConnection sqlConnection1 = new SqlConnection("Your Connection String");
    SqlCommand cmd = new SqlCommand();
    SqlDataReader reader;
    
    cmd.CommandText = "SELECT GETDATE() as CurrentTime";
    cmd.CommandType = CommandType.Text;
    cmd.Connection = sqlConnection1;
    
    sqlConnection1.Open();
    
    reader = cmd.ExecuteReader();
    // Data is accessible through the DataReader object here.
