                using (SqlCommand cmd = new SqlCommand("sp_Cases_ViewAll", con))
                {
                    //if (prioritylev == "")
                    //    cmd.Parameters.AddWithValue("@PriorityLevelKey", DBNull.Value);
                    //else
                    if (string.IsNullOrEmpty(prioritylev))
                    {
                        cmd.Parameters.AddWithValue("@PriorityLevelKey", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@PriorityLevelKey", new Guid(prioritylev));
                    }
                    if(string.IsNullOrEmpty(processkey))
                    {
                        cmd.Parameters.AddWithValue("@ProcessStatusKey", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ProcessStatusKey", new Guid(processkey));
                    }
                    if (string.IsNullOrEmpty(systemuser))
                    {
                        cmd.Parameters.AddWithValue("@SystemUserKey", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@SystemUserKey",  new Guid(systemuser));
                    }
                    
                    cmd.Parameters.AddWithValue("@AccountNumber", accnumber);
                    cmd.Parameters.AddWithValue("@CustomerName", cusname);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        grid_Cases.DataSource = dt;
                        grid_Cases.DataBind();
                    }
                }
            }
