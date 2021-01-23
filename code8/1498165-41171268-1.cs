            DataTable dt = new DataTable();
            SqlDataAdapter sqlAdtp = new SqlDataAdapter();
            string connectionString = "Data Source=local.url;Initial Catalog=databasename;User ID=username;Password=password";
            string sql = "SELECT * FROM shiplabels";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.Text;                   
                    try
                    {
                        sqlAdtp.SelectCommand = cmd;
                        sqlAdtp.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                       
                    }
                }
            }
