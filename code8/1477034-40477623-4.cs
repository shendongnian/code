            string txtBox = someBox.Text;
            using(SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT testing (name) VALUES (@name)";
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtBox;
                    cmd.Connection = conn;
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                }
            }
