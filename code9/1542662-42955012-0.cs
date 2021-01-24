    using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(updateQuery))
                {
                    SqlCommand whenUpdated = new SqlCommand(updateQuery, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader rdr = whenUpdated.ExecuteReader();
                    while (rdr.Read())
                    {
                        string SqlUpdateTime = rdr["last_user_update"].ToString();
                        if (SqlUpdateTime != "")
                        {
                            DateTime SQLasTime = Convert.ToDateTime(SqlUpdateTime);
                            double inMilliseconds = SQLasTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
                            if (inMilliseconds > time)
                            {
                                return true;
                            }
                        }
                    }
                    con.Close();
                    return false;
