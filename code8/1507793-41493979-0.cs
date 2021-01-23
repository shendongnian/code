    using System;
    using System.Data;
    using System.Data.SqlClient;
    
    namespace DataAccess
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Use your database details here.
                var connString = @"Server=localhost\SQL2014;Database=AdventureWorks2012;Trusted_Connection=True;";
    
                //Enter query here, ExecuteScalar returns first column first row only
                //If you need to return more records use ExecuteReader/ExecuteNonQuery instead
                var query = @"SELECT [AccountNumber]
                              FROM [Purchasing].[Vendor]
                              where Name = @Name";
    
                string accountNumber = string.Empty;
    
                //Using statement automatically closes the connection so you don't need to call conn.Close()
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    //Replace @Name as parameter to avoid dependency injection
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                    cmd.Parameters["@name"].Value = "Michael";
                    try
                    {
                        conn.Open();
                        //Cast the return value to the string, if it's an integer then use (int)
                        accountNumber = (string)cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                Console.WriteLine(accountNumber);
                //ReadKey just to keep the console from closing
                Console.ReadKey();
    
            }
        }
    }
