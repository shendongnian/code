    public static class DAL
    {
        private static string _ConnectionString = null;
        static DAL() // A static constructor to initialize the connection string
        {
            _ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }
        public static DataSet GetCategories()
        {
            var ds = new DataSet();
            var sql = "SELECT * FROM Categories";
            using (var con = new SqlConnection(_ConnectionString))
            {
                using (var cmd = new SqlCommand(sql, con))
                {
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(ds);
                    }
                }
            }
            return ds;
        }
        public static int DeleteCategory(int categoryId)
        {
            int rowsEffected = 0;
            var sql = "DELETE FROM Categories WHERE Id = @Id";
            using (var con = new SqlConnection(_ConnectionString))
            {
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = categoryId;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return rowsEffected;
        }
    }
