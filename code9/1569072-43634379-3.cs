    public List<string> GetDatabaseList()
    {
        List<string> list = new List<string>();
        string conString = "Data Source=yourDataSource; Integrated Security=True;"; //without database declaration
    
        using (SqlConnection con = new SqlConnection(conString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
            {
                using (IDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(dr[0].ToString());
                    }
                }
            }
        }
        return list;    
    }
    public List<string> GetTables(string database)
    {
        string connectionString="Data Source=yourDataSource;Initial Catalog="+database+"; Integrated Security=True;";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            DataTable schema = connection.GetSchema("Tables");
            List<string> TableNames = new List<string>();
            foreach (DataRow row in schema.Rows)
            {
                TableNames.Add(row[2].ToString());
            }
            return TableNames;
    }
