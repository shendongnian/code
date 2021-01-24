     try
                {
                    SqlConnection con = new SqlConnection(Constr);
                    using (con)
                    {
                        con.Open();
                        StringBuilder query = $"IF EXISTS (SELECT * FROM sys.tables WHERE name = '{tableName}') SELECT 1 ELSE Select 0;;
                        Exists = int.Parse(sqlQuery.ExecuteScalar().ToString())==1;
                        con.Close();
                    }
    
                }
                catch{}
