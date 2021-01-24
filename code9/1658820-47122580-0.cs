    public int ExecuteNonQuery(string sql, CommandType commandType, params SqlParameter[] parameters)
    {
        using (var con = new SqlConnection("ConnectionString"))
        {
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.CommandType = commandType;
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
