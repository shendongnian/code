    var params = new SQLParameter[]
    {
        new SqlParameter("@P1", SqlDbType.Int).Value = intValue,
        new SqlParameter("@P2", SqlDbType.NVarChar).Value = stringValue,
        new SqlParameter("@P3", SqlDbType.DateTime).Value = dateTimeValue
    };
    return Database.ExecuteNonQuery("INSERT INTO .... VALUES (@P1, @P2, @P3)", params);
