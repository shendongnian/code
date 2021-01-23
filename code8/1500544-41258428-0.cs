    name = "DBConnection"
    providerName = "System.Data.SqlClient"
    connectionString = "Data Source=Source;Initial Catalog=DatabaseName;User ID=User;Password=Password;"
    conn = new SqlConnection();
    conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
