    OracleConnectionStringBuilder sb = new OracleConnectionStringBuilder();
    sb.DataSource = "<your datasource>";
    sb.UserID = "library";
    sb.Password = "library";
    OracleConnection conn = new OracleConnection(sb.ToString());
    conn.Open();
