    var str = new DbConnectionStringBuilder(false);
    str.Add("Data Source", db);
    str.Add("User ID", user);
    str.Add("Password", pw);
    var con = new Devart.Data.Oracle.OracleConnection(str);
