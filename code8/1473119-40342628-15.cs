    public IDataRecord GetSomeData(string fields, string table, string where = null, int count = 0)
        {
            string sql = "SELECT @Fields FROM @Table WHERE @Where";
    
            using (SqlConnection cn = new SqlConnection(db.getDBstring(Globals.booDebug)))
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.Add("@Fields", SqlDbType.NVarChar, 255).Value = where;
    
                cn.Open();
    
                using (IDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        return (IDataRecord)rdr;
                    }
                }
            }
        }
    }
