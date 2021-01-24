            string msg = string.Empty;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_insertEmp", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpName", EmpName);
                    cmd.Parameters.AddWithValue("@ConNo", ConNo);
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i == 1)
                    {
                        msg = "True";
                    }
                    else
                    {
                        msg = "false";
                    }
                }
            }
            return msg;
        }
