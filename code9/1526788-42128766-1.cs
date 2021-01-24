    private void Form1_Load(object sender, EventArgs e)
    {
         try
        {
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
