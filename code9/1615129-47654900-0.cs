    void SaveTable(DataTable dt)
        {
            string[] inserts;
            try
            {
                inserts = SqlHelper.GenerateInserts(dt, null, null, null);
                foreach (string s in inserts)
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandText = s;
                    cmd.Connection = _connection;
                    int n = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                SaveOk = false;
            }
        }
