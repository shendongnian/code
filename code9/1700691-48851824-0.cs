    namespace ConsoleApp5
    {
        class Program
        {
            private static MySqlConnection connection;
            private static string server;
            private static string database;
            private static string uid;
            private static string password;
    
            public static void Main(string[] args)
            {
    
                server = "localhost";
                database = "database";
                uid = "domica";
                password = "domica";
                string connectionString;
                connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
    
                connection = new MySqlConnection(connectionString);
                connection.Open();
    
                Insert();
            }
            public static void Insert()
            {
                Console.Write("Ukucaj nesto:");
                var kucaj = Console.ReadLine();
                string query = "INSERT INTO table1 (Ci) VALUES (@tt);";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@tt", kucaj);
                cmd.ExecuteNonQuery();
            }
    
          }
    }
    
