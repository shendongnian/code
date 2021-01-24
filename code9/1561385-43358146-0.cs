     public static DataTable GetData()
            {
                String callProcedure = "exec my_proc";
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection("connection string here!"))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = callProcedure;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                        {
                            adp.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
