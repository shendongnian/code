    using System;
    using System.Data;
    
    using MySql.Data;
    using MySql.Data.MySqlClient;
    
    public class Tutorial1
    {
        public static void Main()
        {
            string connStr = "server=localhost;user=root;database=world;port=3306;password=******;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                // Perform database operations
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
        }
    }
