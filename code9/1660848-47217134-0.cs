      using (var conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SchoolPlusDBContext"].ConnectionString))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    using (var cmd = new SqlCommand("SELECT Name FROM Customer where  ISNUMERIC(id)=1 and Id=1")) // After this command is executed, its transaction becomes null.
                    //using (var cmd = new SqlCommand("SELECT Name FROM Customer  WHERE ID = '000001'")) // This runs fine.
                    {
                        cmd.Connection = conn;
                        cmd.Transaction = trans;
                        var res = cmd.ExecuteScalar();
                    }
                    trans.Commit();
                }
            }
