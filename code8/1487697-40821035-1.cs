    public static IEnumerable<T> QueryAll<T>(string table)
    { 
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ToString());
        using (con)
        {
            string sql = String.Format("SELECT * FROM {0}", table);
            IEnumerable<T> ie = con.Query<T>(sql, null);
            return ie;
        }
    }
