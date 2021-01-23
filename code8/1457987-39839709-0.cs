    using System;
    using System.Data.SqlClient;
    
    namespace ConsoleApp1
    {
        public class Program
        {
            public static void Main(String[] args)
            {
                using (var connection = new SqlConnection("server=(local);database=Northwind;integrated security=yes;"))
                {
                    connection.Open();
    
                    using (var command = new SqlCommand("select * from Shippers", connection))
                    {
                        using (var dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                Console.WriteLine("Company name: {0}", dataReader[1]);
                            }
                        }
                    }
                }
    
                Console.ReadKey();
            }
        }
    }
