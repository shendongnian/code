    public DataSet ExecuteQuery(string[] Query,  TableMap[] TableMappings)
    {
        // using statement will ensure proper closing and DISPOSING of the objects
        using(MySqlConnection con = new MySqlConnection(_serveraddress))
        using(MySqlCommand com = con.CreateCommand())
        {
            con.Open();
            // Not needed, it is the default
            // com.CommandType = System.Data.CommandType.Text;
            
            foreach (string st in Query)
            {
                // Are you sure the st is properly terminated with a semicolon?
                com.CommandText = com.CommandText + st;
            }
            com.CommandTimeout = int.MaxValue;
            using(MySqlDataAdapter adapter = new MySqlDataAdapter(com))
            {
                foreach (TableMap tm in TableMappings)
                   adapter.TableMappings.Add(tm.SourceTable, tm.TableSet);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;
           }
        }
    }
