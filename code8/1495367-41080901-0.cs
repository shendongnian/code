    public static DataTable InsertConnect(ComboBox Site , ComboBox server , ComboBox Host , ComboBox Domain , Label Price)
    {
        using (var cn = new SqlConnection(Server.Connection))
        {
            cn.Open();
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = cn;
                cmd.CommandText = "insert into tblPrice(Site,Server,Host,Domain,Price) values (@Site, @Server, @Host, @Domain, @Price)"; 
                var parameters = new[]
                {
                    new SqlParameter { ParameterName = "@Site", .SqlDbType = SqlDbType.VarChar, .Value = Site.text },
                    new SqlParameter { ParameterName = "@Server", .SqlDbType = SqlDbType.VarChar, .Value = server.text },
                    new SqlParameter { ParameterName = "@Host", .SqlDbType = SqlDbType.VarChar, .Value = Host.Text },
                    new SqlParameter { ParameterName = "@Domain", .SqlDbType = SqlDbType.VarChar, .Value = Domain.Text },
                    new SqlParameter { ParameterName = "@Price", .SqlDbType = SqlDbType.VarChar, .Value = Price.Text }
                }
                cmd.Parameters.AddRange(parameters);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
