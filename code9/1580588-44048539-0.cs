    using System;
    using System.Data.OleDb;
    using System.IO;
    
    namespace DataLib
    {
        public class Operations1
        {
            public Exception InsertException { get; set; }
            private OleDbConnectionStringBuilder Builder = new OleDbConnectionStringBuilder
            {
                Provider = "Microsoft.ACE.OLEDB.12.0",
                DataSource = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database1.accdb")
            };
            public Operations1()
            {
                if (!(File.Exists(Builder.DataSource)))
                {
                    throw new FileNotFoundException("Failed to find application's database");
                }
            }
            public bool AddNewRow(string CompanyName, string ContactName, ref int Identfier)
            {
    
                bool success = true;
                int affected = 0;
    
                try
                {
                    using (OleDbConnection cn = new OleDbConnection { ConnectionString = Builder.ConnectionString })
                    {
                        using (OleDbCommand cmd = new OleDbCommand { Connection = cn })
                        {
                            cmd.CommandText = @"INSERT INTO Customer (CompanyName,ContactName) 
                                VALUES (@CompanyName, @ContactName)";
    
                            cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
                            cmd.Parameters.AddWithValue("@ContactName", ContactName);
    
                            cn.Open();
    
                            affected = cmd.ExecuteNonQuery();
                            if (affected == 1)
                            {
                                cmd.CommandText = "Select @@Identity";
                                Identfier = Convert.ToInt32(cmd.ExecuteScalar());
                                success = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    InsertException = ex;
                    success = false;
                }
                return success;
            }
        }
    }
