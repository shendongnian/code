    public List<Tables> GetTables(string databaseName, string connectionString, string type)
    {
        var connection = connectionFactory.GetConnection(connectionString, type);
        return connection.GetTables(connection);
    }
    public List<Tables> GetColumns(string databaseName, string connectionString, string type)
    {
        var connection = connectionFactory.GetConnection(connectionString, type);
        return connection.GetColumns(connection);
    }
    private IEnumerable<Table> GetTables(DbConnection connection)
    {
        connection.Open();
        list = con.GetSchema("Tables").AsEnumerable()
                  .Select(t => new Tables
                  {
                       Name = t["TABLE_SCHEMA"].ToString() + "." + t[2].ToString()
                  }).ToList();
        connection.Close();
     }
    private IEnumerable<Table> GetColumns(DbConnection connection)
    {
        connection.Open();
        list = con.GetSchema("COLUMNS").AsEnumerable()
                  .Select(t => new Tables
                  {
                       Name = t["COLUMN_SCHEMA"].ToString() + "." + t[2].ToString()
                  }).ToList();
        connection.Close();
     }
    public class ConnectionFactory
    {
         public DbConnection GetConnection(string connectionString, string type)
         {
               switch(type)
               {
                    case "mysql":
                         return new MySqlConnection(connectionString);
                    case "mssql":
                         return new SqlConnection(connectionString);
                    default:
                         throw new UnsupportedException($"{type} not supported.");
               }
         }
    }
