    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Dynamic;
    
    namespace ConsoleApp1
    {
        public class Program
        {
            public static IEnumerable<dynamic> GetData(String cmdText)
            {
                using (var connection = new SqlConnection("server=(local);database=Northwind;integrated security=yes;"))
                {
                    connection.Open();
    
                    using (var command = new SqlCommand(cmdText, connection))
                    {
                        using (var dataReader = command.ExecuteReader())
                        {
                            var fields = new List<String>();
    
                            for (var i = 0; i < dataReader.FieldCount; i++)
                            {
                                fields.Add(dataReader.GetName(i));
                            }
    
                            while (dataReader.Read())
                            {
                                var item = new ExpandoObject() as IDictionary<String, Object>;
    
                                for (var i = 0; i < fields.Count; i++)
                                {
                                    item.Add(fields[i], dataReader[fields[i]]);
                                }
    
                                yield return item;
                            }
                        }
                    }
                }
            }
    
            public static void Main(String[] args)
            {
                foreach (dynamic row in GetData("select * from Shippers"))
                {
                    Console.WriteLine("Company name: {0}", row.CompanyName);
                    Console.WriteLine();
                }
    
                Console.ReadKey();
            }
        }
    }
