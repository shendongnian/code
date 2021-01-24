    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
    {
        UserID = "Some User ID",
        Password = "Some Database Password",
        InitialCatalog = "Some Initial Catalog",
        DataSource = "Some Data Source"
    };
    string connectionString = builder.ToString();
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        //...
    }
