    static SqlConnection sqlConn = null;
    public static SqlConnection GetConnection {
    get {
        if (sqlConn == null)
        {
            string cons = ConfigurationManager.ConnectionStrings["CTXDb"].ConnectionString;
            sqlConn = new SqlConnection(cons)
        }
        return sqlConn ;
    }
    }
