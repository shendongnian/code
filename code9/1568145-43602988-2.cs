    static void Main(string[] args)
        {
            tableName = "Employee";
            string condition = "'User4'";
            Delete("Name", condition);
        }
    public static void Delete(string field, string condition)
        {
            string _conString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection connect = new SqlConnection(_conString))
            {
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = connect;
                adp.SelectCommand.CommandText = "delete  from " + tableName + " where " + field + " = " + condition;
                DataSet ds = new DataSet();
                connect.Open();
                adp.Fill(ds);
                connect.Close();
            }
        }
