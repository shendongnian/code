    using System;
    using System.Data.SqlClient;
    using System.Configuration;
    using System.Data;
    using System.Collections.Generic;
    
    namespace MyProgram
    {
    
        class Item
        {
            public string OldValue { get; set; }
            public string NewValue { get; set; }
        }
    
        class Program
        {
            //private static SqlConnection _connection;
    
            private static string connectionString = ConfigurationManager.ConnectionStrings["myConfig"].ConnectionString;
    
            static void Main(string[] args)
            {
                List<Item> items = new List<Item>();
                ReadData(ref items);
    
                UpdateIdSqlTransaction(items);
    
                Console.ReadLine();
            }
    
            private static void ReadData(ref List<Item> items)
            {
                using (var connection = new SqlConnection())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    //_connection = connection;
    
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText =
                        "My Select sql stament with inner joins";
    
                        using (var reader = command.ExecuteReader())
                        {
                            var indexOfColumn3 = reader.GetOrdinal("IDExtObject");
    
                            while (reader.Read())
                            {
                                var extId = reader.GetValue(indexOfColumn3).ToString();
                                string finalId = "Something new...";
    
                                items.Add(new Item() { OldValue = extId, NewValue = finalId });
                            }
                        }
                    }
                }
            }
    
            private static void UpdateIdSqlTransaction(List<Item> items)
            {
                SqlTransaction transaction;
                using (var connection = new SqlConnection())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
    
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.Connection = connection;
                        transaction = connection.BeginTransaction("UpdateTransaction");
                        command.Transaction = transaction;
                        try
                        {
                            foreach (var item in items)
                            {
                                var commandText = "The update SQL statement...";
                                command.CommandText = commandText;
                                command.Parameters.AddWithValue("@ID", item.OldValue);
                                command.Parameters.AddWithValue("@newId", item.NewValue);
                                command.ExecuteNonQuery();
                            }
                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            //Log the exception here. To know, why this failed.
                        }
                    }
                }
            }
        }
    }
