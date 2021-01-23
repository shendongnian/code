    private void button1_Click(object sender, EventArgs e)
    {
        name = txtname.Text;
        pass = Convert.ToInt32(txtpass.Text);
        repass = Convert.ToInt32(txtrepass.Text);
        email = txtemail.Text;
        if (pass != repass)
        {
            MessageBox.Show("Password mismatch");
            return;
        }
        string cmdText = @"INSERT INTO SYSTEM.CUSTOMER 
        (CUSTOMER_NAME, CUSTOMER_EMAIL, CUSTOMER_PASSWORD) 
        VALUES(?,?,?)";
        using(OleDbConnection con = new OleDbConnection(.......))
        using(OleDbCommand cmd = new OleDbCommand(cmdText, con))
        {
             con.Open();
             cmd.Parameters.Add("p1", OleDbType.VarChar).Value = txtname.Text;
             cmd.Parameters.Add("p2", OleDbType.VarChar).Value = txtemail.Text;
             cmd.Parameters.Add("p1", OleDbType.VarChar).Value = txtpass.Text ;
             int rowsUpdated = cmd.ExecuteNonQuery();
             if (rowsUpdated == 0)
             {
                 MessageBox.Show("Record not inserted");
             }
             else 
             {
                MessageBox.Show("Success!");
                MessageBox.Show("User has been created");
             }
        }
        Form1 login = new Form1();
        login.Show();
    }
