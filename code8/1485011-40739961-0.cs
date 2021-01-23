    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MySql.Data.MySqlClient;
    namespace MySQLtest
    {
        class Program
        {
            static void Main(string[] args)
            {   string dbHost = "";//db address, for example localhost
                string dbUser = "";//dbusername
                string dbPass = "";//dbpassword
                string dbName = "";//db name
                string connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;
                MySqlConnection conn = new MySqlConnection(connStr);
                MySqlCommand command = conn.CreateCommand();
                conn.Open();
    
                String cmdText = "SELECT * FROM member WHERE level < 50";
                MySqlCommand cmd = new MySqlCommand(cmdText, conn);
                MySqlDataReader reader = cmd.ExecuteReader(); //execure the reader
                while (reader.Read())
                {
                    for (int i = 0; i < 4; i++)
                    {
                        String s = reader.GetString(i);
                        Console.Write(s + "\t");
                    }
                    Console.Write("\n");
                }
    
    
                Console.ReadLine();
                conn.Close();
            }
        }
    }
