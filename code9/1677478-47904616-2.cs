    public bool DoesEmailAlreadyExist(string email)
        {
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["sqlcon"].ToString()))
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("Sp_doesEmailExist", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@email", email);
                        SqlParameter p = cmd.Parameters.Add("@exists", SqlDbType.Char, 1);
                        p.Direction = ParameterDirection.Output;
                        //cmd.Parameters.Add(p);
                        cmd.ExecuteNonQuery();
                        return cmd.Parameters["@exists"].Value.ToString() == "Y";
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
