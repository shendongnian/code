    using (var sqlconn = new ...)
    using (var sqlcom = new ...)
    {
        sqlcon.open();
        sqlcom.ExecuteNonQuery();
    }
