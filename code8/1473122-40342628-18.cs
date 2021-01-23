    public IEnumerable<IDataRecord> GetSomeData(IEnumerable<string> fields, string table, string where = null, int count = 0)
    {
        var predicate = string.IsNullOrEmpty(where) ? "" : " WHERE " + where;
        string sql = string.Format("SELECT {0} FROM {1} {2}", string.Join(",", fields), table, predicate);
        using (SqlConnection cn = new SqlConnection(db.getDBstring(Globals.booDebug)))
        using (SqlCommand cmd = new SqlCommand(sql, cn))
        {
            cn.Open();
            using (IDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    yield return (IDataRecord)rdr;
                }
            }
        }
    }
