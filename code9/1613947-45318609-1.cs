    public static class DAL
    {
        private static IDBHelper _DB;
        static DAL() // A static constructor to initialize _DB
        {
             // initialize connection string from config file
            var connectionstring = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            _DB = DBHelperFactory.GetInstance(DataBaseType.SQLServer, connectionstring);
        }
        public static DataSet GetCategories()
        {
            var sql = "SELECT * FROM Categories";
            return _DB.FillDataSet(sql, CommandType.Text);
        }
        public static int DeleteCategory(int categoryId)
        {
            var sql = "DELETE FROM Categories WHERE Id = @Id";
            var param = _DB.CreateParameter("@Id", ADONETType.Int, categoryId);
            return _DB.ExecuteNonQuery(sql, CommandType.Text, param);
        }
    }
