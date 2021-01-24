    using System;
    using System.Data;
    using System.Data.OleDb;
    
    namespace Demo
    {
        class Class1
        {
            void Test1()
            {
                var word = "Place a hard code value here";
                var query11 = @"SELECT  System.DateCreated,
                                    System.ItemName,
                                    System.ItemUrl,
                                    System.Size,
                                    System.Search.HitCount FROM SystemIndex " +
                                                @"WHERE scope ='file:D:/TaalTipsDocumenten' AND CONTAINS('" + word + "') ";
    
    
                DataTable dt = new DataTable();
    
                using (OleDbConnection connection = new OleDbConnection(@"Provider=Search.CollatorDSO;Extended Properties=""Application=Windows"""))
                {
                    using (OleDbCommand command = new OleDbCommand(query11, connection))
                    {
                        connection.Open();
                        try
                        {
                            dt.Load(command.ExecuteReader());
                            Console.WriteLine(dt.Rows.Count);
                        }
                        catch (Exception)
                        {
                            // place break-pointhere
    
                            
                        }
    
                    }
                }
            }
            void Test2()
            {
                var word = "Place a hard code value here";
                var query11 = @"SELECT  System.DateCreated,
                                    System.ItemName,
                                    System.ItemUrl,
                                    System.Size,
                                    System.Search.HitCount FROM SystemIndex " +
                                                @"WHERE scope ='file:D:/TaalTipsDocumenten' AND CONTAINS('" + word + "') ";
    
    
                using (OleDbConnection connection = new OleDbConnection(@"Provider=Search.CollatorDSO;Extended Properties=""Application=Windows"""))
                {
                    using (OleDbCommand command = new OleDbCommand(query11, connection))
                    {
                        connection.Open();
                        try
                        {
                            var reader = command.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine($"Date: {reader.GetDateTime(0)}");
                                }
                            }
                        }
                        catch (Exception)
                        {
                            // place break-pointhere
    
    
                        }
    
                    }
                }
            }
        }
    }
