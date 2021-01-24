            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spInsOrg", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                var outParam = cmd.Parameters.Add("@orgID", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@orgName", SqlDbType.NVarChar).Value = txtOrgName.Text;
                cmd.Parameters.Add("@orgCity", SqlDbType.NVarChar).Value = txtCity.Text;
                cmd.Parameters.Add("@orgArea", SqlDbType.NVarChar).Value = txtArea.Text;
                cmd.Parameters.Add("@orgTel", SqlDbType.NVarChar).Value = txtTele.Text;
                cmd.Parameters.Add("@orgEmail", SqlDbType.NVarChar).Value = txtEmail.Text;
                cmd.Parameters.Add("@orgType", SqlDbType.NVarChar).Value = txtOrgType.Text;
                cmd.Parameters.Add("@orgStatus", SqlDbType.NVarChar).Value = txtStatus.Text;
                cmd.Parameters.Add("@strOwner", SqlDbType.VarChar).Value = User.Identity.Name;
                cmd.Parameters.Add("@db_tstamp", SqlDbType.DateTime2).Value = DateTime.Now;
                conn.Open();
                cmd.ExecuteNonQuery();
                var orgId = (int)outParam.Value;
                SqlCommand cmdloc = new SqlCommand("spInsLoc", conn);
                cmdloc.CommandType = CommandType.StoredProcedure;
                
            }
