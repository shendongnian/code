    private void but_log_in_Click(object sender, EventArgs e)
    {
        if (tbx_username.Text == "" || Tbx_Password.Text == "")
        {
            MessageBox.Show("Please provide UserName and Password");
            return;
        }
        try
        {
            //Create SqlConnection
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("Select * from Tbl_Cashier where FName=@username and Password=@password", con))
            using (SqlDataAdapter adapt = new SqlDataAdapter(cmd))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@username", tbx_username.Text);
                cmd.Parameters.AddWithValue("@password", Tbx_Password.Text);
                HabibisGrll.Globals.sss = tbx_username.Text;
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                con.Close();
                int count = ds.Tables[0].Rows.Count;
                //If count is equal to 1, than show frmMain form
                if (count == 1)
                {
                    HabibisGrll.Globals.cashier = Int32.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString());
                    MessageBox.Show("ID Number : " + ds.Tables[0].Rows[0].ItemArray[0] + Environment.NewLine + "USER : " + ds.Tables[0].Rows[0].ItemArray[1], "User INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    HabibisGrll fm = new HabibisGrll();
                    fm.Show();
                }
                else
                {
                    MessageBox.Show("Login Failed!");
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    } 
