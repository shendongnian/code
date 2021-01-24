    using System;
    using System.Data.SqlClient;
    
    namespace WindowsFormsApplication1
    {
        public class Operations
        {
            /// <summary>
            /// Replace with your SQL Server name
            /// </summary>
            private string Server = "KARENS-PC";
            /// <summary>
            /// Database in which data resides, see SQL_Script.sql
            /// </summary>
            private string Catalog = "ForumExamples";
            /// <summary>
            /// Connection string for connecting to the database
            /// </summary>
            private string ConnectionString = "";
            /// <summary>
            /// Setup the connection string
            /// </summary>
            public Operations()
            {
                ConnectionString = $"Data Source={Server};Initial Catalog={Catalog};Integrated Security=True";
            }
            public bool InsertDepartment(string pDepartment, ref int pIdentifier)
            {
                using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = cn })
                    {
                        cmd.CommandText = "SELECT Name FROM Departments WHERE Name = @Name";
                        cmd.Parameters.AddWithValue("@Name", pDepartment);
    
                        cn.Open();
                        if (cmd.ExecuteScalar() == null)
                        {
                            cmd.CommandText = @"
                            INSERT INTO dbo.Departments (Name) 
                            VALUES (@Name); SELECT CAST(scope_identity() AS int);";
                            pIdentifier = Convert.ToInt32(cmd.ExecuteScalar());
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }
    }
