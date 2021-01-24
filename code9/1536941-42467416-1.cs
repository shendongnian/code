    private void insertuser()
    {
    
    string cs = ConfigurationManager.ConnectionStrings["IBS_3"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(cs))
                {
    
                    SqlCommand cmd = new SqlCommand("spInsUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
    
                    cmd.Parameters.Add("userFName", SqlDbType.NVarChar).Value = txtFName.Text;
                    cmd.Parameters.Add("userLName", SqlDbType.NVarChar).Value = txtLName.Text;
                    cmd.Parameters.Add("userMoNo", SqlDbType.NVarChar).Value = txtMoNo.Text;
                    cmd.Parameters.Add("userEmail", SqlDbType.NVarChar).Value = txtEmail.Text;
                    cmd.Parameters.Add("userCity", SqlDbType.NVarChar).Value = txtCity.Text;
                    cmd.Parameters.Add("userArea", SqlDbType.NVarChar).Value = txtArea.Text;
                    cmd.Parameters.Add("userType", SqlDbType.NVarChar).Value = txtUserType.Text;
                    cmd.Parameters.Add("userStatus", SqlDbType.NVarChar).Value = txtStatus.Text;
                    cmd.Parameters.Add("@strOwner", SqlDbType.VarChar).Value = User.Identity.Name;
                    cmd.Parameters.Add("@db_tstamp", SqlDbType.DateTime2).Value = DateTime.Now;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
    }
