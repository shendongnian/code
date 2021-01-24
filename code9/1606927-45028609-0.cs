        if (login.textBox1.Text == "admin" && login.textBox2.Text == "root")
                {
                    button2.Enabled = true;
        Program.UserType="admin";
                }
                else
                {
                    button2.Enabled = false;
     Program.UserType="User";
    
                }
