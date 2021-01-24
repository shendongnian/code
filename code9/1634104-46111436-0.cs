    using(var oConn = new SqlConnection())
    {
        oConn.Open();
        using (var oCmd = oConn.CreateCommand())
        {
            ...
        }
    }
