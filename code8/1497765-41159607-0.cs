    public List<Tables> GetTables(string databaseName, string connectionString, string type)
    {
        var list = new List<Tables>();
        if (type == 'mysql')
        {
            using (var con = new MySqlConnection(connectionString))
            {
                list.AddRange(GetTables(con));
            }
        }
        else
        {
            using (var con = new SqlConnection(connectionString))
            {
                list.AddRange(GetTables(con));
            }
        }
        return list;
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
