    public DataTable SelectData(string query)
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection("Your Connection String here"))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                        {
                            adp.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
