        static void Main(string[] args)
        {
            try
            {
                CreateDBF();
                Console.WriteLine(ReadDB());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static string dbfDirectory = @"c:\Test\dbTest";
        private static string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbfDirectory + ";Extended Properties = dBase IV";
        public static bool CreateDBF()
        {            
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.CommandText = "Create Table CustomProperties ([Public] char(50))";
                command.ExecuteNonQuery();
                connection.Close();
            }
            InsertDataIntoDBF(dbfDirectory + "\\CustomProperties.DBF");
            return true;
        }
        public static bool InsertDataIntoDBF(string path)
        {
            string query = @"INSERT INTO CustomProperties ([Public]) VALUES (@Public)";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@Public", "True");
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            return true;
        }
        public static string ReadDB()
        {
            string res = string.Empty;
            string query = @"SELECT * FROM CustomProperties";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@Public", "True");
                connection.Open();
                res = (string)command.ExecuteScalar();
                connection.Close();
            }
            return res;
        }
