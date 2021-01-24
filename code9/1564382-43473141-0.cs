            static void Main(string[] args)
            {
               var policy = Policy
                    .Handle<SqlException>()
                    .Retry(3);
    
                try
                {
                   policy.Execute(() => DoSomething());
                }
                catch (SqlException exc)
                {
                   // log exception   
                }
            }
    
            private static void DoSomething()
            {
                using (SqlConnection conn = new SqlConnection(""))
                {
                    conn.Open();
                    string requeteFou = "select XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
    
                    using (SqlCommand command = new SqlCommand(requeteFou, conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (!reader.HasRows) return;
                            while (reader.Read())
                            {
                                // do job
                            }
                        }
                    }
                }
            }
