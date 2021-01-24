    // Get sql query and add where clause to it.
    string sqlString = System.Configuration.ConfigurationManager.AppSettings["test"] + " where id=@id";
   
    // Execute sqlString 
    SqlConnection sqlConnection1 = new SqlConnection("Your Connection String");
    SqlCommand cmd = new SqlCommand();
    SqlParameter param  = new SqlParameter();
    param.ParameterName = "@id";
    param.Value         = Textbox1.Text;
    cmd.Parameters.Add(param);
    SqlDataReader reader;
    
    cmd.CommandText = sqlString;
    cmd.CommandType = CommandType.Text;
    cmd.Connection = sqlConnection1;
    
    sqlConnection1.Open();
    
    reader = cmd.ExecuteReader();
    // Data is accessible through the DataReader object here.
    
    sqlConnection1.Close();
