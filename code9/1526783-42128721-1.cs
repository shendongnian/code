    private void txtleavetype_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                txtleavetype.Items.Clear();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand(" select leavestype from hrsettings", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtleavetype.Items.Add(dr["leavestype"]);
                }
                dr.Close();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
