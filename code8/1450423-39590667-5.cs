    string cnnString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
    SqlConnection cnn = new SqlConnection(cnnString);
    SqlCommand cmd = new SqlCommand();
    cmd.Connection = cnn;
    cmd.CommandType = System.Data.CommandType.StoredProcedure;
    cmd.CommandText = "ProcedureName";
    //add any parameters the stored procedure might require
    cnn.Open();
    object o = cmd.ExecuteScalar();
    cnn.Close();
