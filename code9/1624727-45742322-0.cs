    var sqlBuilder = new SqlConnectionStringBuilder
    {
        DataSource = "localhost",
        InitialCatalog = "mainDB",
        Password = "Y;9r.5JQ6cwy@)V_",
        UserID = "sqluser"
    };
            
    con = new SqlConnection(sqlBuilder.ToString());
