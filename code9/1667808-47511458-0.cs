    string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
    using(SqlConnection con = new SqlConnection(connectionString))
    {
        //Your code goes here
    }
