    public static int ExecuteQuery()
            {
                using (SqlConnection con = new SqlConnection("Your connection String here"))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = "select top 1 id from yourtable order by id desc";
                        cmd.CommandType = CommandType.Text;
                        int result = cmd.ExecuteNonQuery();
                        return result;
                    }
                }
            }
