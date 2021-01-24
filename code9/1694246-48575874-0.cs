        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string fname = txtFirst.Text;
            string lname = txtLast.Text;
            string middle = txtMiddle.Text;
            string dob = txtDOB.Text;
            string add1 = txtAdd1.Text;
            string add2 = txtAdd2.Text;
            string dateofjoin = txtDateofjoin.Text;
            SqlConnection con = new SqlConnection(Connection.ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("EmployeeRegister", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@firstname", fname);
            cmd.Parameters.AddWithValue("@lastname", lname);
            cmd.Parameters.AddWithValue("@middlename", middle);
            cmd.Parameters.AddWithValue("@dateofbirth", dob);
            cmd.Parameters.AddWithValue("@address1", add1);
            cmd.Parameters.AddWithValue("@address2", add2);
            cmd.Parameters.AddWithValue("@dateofjoin", dateofjoin);
            cmd.Parameters.AddWithValue("@active", CheckActive.Checked ? "1" : "0");
            cmd.ExecuteNonQuery();
            con.Close();
        }
