    public static string m_strMySQLConnectionString;
    static MySqlConnection m_mySqlConnection;
    
    static void Main(string[] args)
    {
      m_strMySQLConnectionString = ConfigurationManager.AppSettings["DBConnectionString"].ToString();
      m_mySqlConnection = null;
     }
