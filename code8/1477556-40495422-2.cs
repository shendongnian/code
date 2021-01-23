    public static Tuple<int, string> GetIDAndString(string term)
    {
        int ID = 0;
        string status = string.Empty;
        using (SqlConnection con = GetConnection())
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            
            cmd.CommandText = @"SELECT t.TableID, t.Status
                                FROM Table t WITH (NOLOCK) /* I know NOLOCK is not causing the mistake as far as I know */
                                WHERE t.Term = @term";
            cmd.Parameters.AddWithValue("@term", term);
            
            using(SqlDataReader myReader = cmd.ExecuteReader())
            {
                while(myReader.Read())
                {
                     ID = myReader.IsDBNull(0) ? 0 : myReader.GetInt32(0);
                     status = myReader.IsDBNull(1) ? string.Empty : myReader.GetString(1).Trim();
                }
            }
            
        }
        return new Tuple<int, string>(ID, status);
    }
