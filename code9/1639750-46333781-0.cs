    public void ProcessRequest(HttpContext context)
    {
      if (context.Request.QueryString["search"] == null) return;
      string parameterContent= context.Request.QueryString["search"];
     
      using (MySqlConnection conn = new MySqlConnection(connstr))
            {
                using (MySqlCommand cmd = new MySqlCommand("Select imageColumn from imagetable where imageidintable = @search", conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@search", parameterContent));
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        reader.Read();
                        context.Response.BinaryWrite((Byte[])reader[reader.GetOrdinal("imageColumn ")]);
                        reader.Close();
                    }
                }
            }
    }
