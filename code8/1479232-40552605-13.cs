    var city = "";
    var state = "tx";
    var sqlQuery = "
        select *
        from
            Customers
        where
            state=@State
    ";
    
    if (!string.IsNullorEmpty(city))
    {
        sqlQuery += "
                AND city=@City";
    }
    
    var conn =  new SqlConnection("Server=(local);DataBase=Northwind;Integrated Security=SSPI");
    conn.Open();
    
    SqlCommand cmd = new SqlCommand(sqlQuery, conn);
    
    if (!string.IsNullorEmpty(city))
    {
        SqlParameter param  = new SqlParameter();
        param.ParameterName = "@City";
        param.Value         = city;
        cmd.Parameters.Add(param);
    }
    
    SqlParameter param  = new SqlParameter();
    param.ParameterName = "@State";
    param.Value         = state;
    cmd.Parameters.Add(param);
    
    var reader = cmd.ExecuteReader();
