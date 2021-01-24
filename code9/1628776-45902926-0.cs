    public IEnumerable<TReturn> Queries<TParent, TChild, TReturn>(string sql, Func<TParent, TChild, TReturn> map, string splitOn = "ID")
            {
                using (IDbConnection conn = new SqlConnection(ConfigurationManager.AppSettings["MyConnection"]))
                {
                    conn.Open();
    
                    return conn.Query(sql, map, splitOn: splitOn);
                }
            }
