        public void MainAccess(int _i)
        {
            DataTable dt = ds.Tables[_i];
            string sql = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
            sql = sql + "INSERT INTO "+ _tableString[_i] + " values('";
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                sql += dt.Rows[i][j].ToString().Trim();
                if (j != dt.Columns.Count - 1)
                {
                    sql += "','";
                }
                else
                {
                    sql += "')";
                }
            }
            ExecuteQuery(sql);
            sql = null;
        }
    }
