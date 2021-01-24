    using System;
    using System.Data;
    using Dapper;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    
    namespace TestConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<DataItemDTO> dataItems = GetDataItems();
    
                var _selectSql = @"SELECT CustomerId, Name, BalanceDue from [dbo].[CustomerAccount]";
    
                var _insertSql = @"INSERT INTO [dbo].[CustomerAccount]
                                           ([CustomerId]
                                           ,[Name]
                                           ,[BalanceDue])
                                     VALUES
                                           (@CustomerId
                                           ,@Name
                                           ,@BalanceDue)";
    
    
    
                using (IDbConnection cn = new SqlConnection(@"Server=localhost\xxxxxxx;Database=xxxxdb;Trusted_Connection=True;"))
                {
                    var rows = cn.Execute(_insertSql, dataItems,null,null,null );
    
                    dataItems.Clear();
    
                    var results = cn.Query<DataItemDTO>(_selectSql);
    
                    foreach (var item in results)
                    {
                        Console.WriteLine("CustomerId: {0} Name {1} BalanceDue {2}", item.CustomerId.ToString(), item.Name, item.BalanceDue.ToString());
                    }
                    
                    
                }
    
                Console.WriteLine("Press any Key");
                Console.ReadKey();
    
            }
    
            private static List<DataItemDTO> GetDataItems()
            {
                List<DataItemDTO> items = new List<DataItemDTO>();
    
                items.Add(new DataItemDTO() { CustomerId = 1, Name = "abc1", BalanceDue = 11.58 });
                items.Add(new DataItemDTO() { CustomerId = 2, Name = "abc2", BalanceDue = 21.57 });
                items.Add(new DataItemDTO() { CustomerId = 3, Name = "abc3", BalanceDue = 31.56 });
                items.Add(new DataItemDTO() { CustomerId = 4, Name = "abc4", BalanceDue = 41.55 });
                items.Add(new DataItemDTO() { CustomerId = 5, Name = "abc5", BalanceDue = 51.54 });
                items.Add(new DataItemDTO() { CustomerId = 6, Name = "abc6", BalanceDue = 61.53 });
                items.Add(new DataItemDTO() { CustomerId = 7, Name = "abc7", BalanceDue = 71.52 });
                items.Add(new DataItemDTO() { CustomerId = 8, Name = "abc8", BalanceDue = 81.51 });
    
                return items;
            }
        }
    }
 
