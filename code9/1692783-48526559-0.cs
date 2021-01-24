    using (var cnn = new SqlConnection(WebConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString))
                    {
                        cnn.Open();
                        using (var cmd = new SqlCommand(sql.ToString(), cnn))
                        {
                            cmd.CommandType = System.Data.CommandType.Text;    
                            cmd.ExecuteNonQuery();
                        }
                    }
