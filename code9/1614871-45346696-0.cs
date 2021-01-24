        public SqlConnection conn;
        public SqlCommand cmd;
        public SqlDataAdapter da;
        public DataTable dt;
        public DataSet ds;
        public void SqlDbConnect()
        {
            conn = new SqlConnection($"Data Source={server};User ID={user};Password={password};");
            conn.Open();
        }
        public void SqlQuery(string queryText)
        {
            cmd = new SqlCommand(queryText, conn);
        }
        public DataTable QueryEx()
        {
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void NonQueryEx()
        {
            cmd.ExecuteNonQuery();
        }
