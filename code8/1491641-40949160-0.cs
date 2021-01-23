    private void button1_Click(object sender, EventArgs e)
    {
        if (dbcontext != null)
            dbcontext.Dispose();
        dbcontext = new mcshonsey_FinalProject.UserShowDBEntities();
            dbcontext.UserTables
                .OrderBy(entry => entry.UserID)
                .Load(); 
        if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
        {
            MessageBox.Show("You must enter a password or username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            textBox1.Focus();
        }
        /*else
        {
            ShowSelectForm ssf = new ShowSelectForm(this, sort);
            Hide();
            ssf.Show();
        }*/
        
        var user =
            from use in dbcontext.UserTables
            where use.UserName == textBox1.Text && use.Password == textBox2.Text
            select use;
        if (Enumerable.Count(user) > 0)
        {
            ShowSelectForm ssf = new ShowSelectForm(this, sort);
            Hide();
            ssf.Show();
        }
        else
        {
            MessageBox.Show("Incorrect username and/or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            textBox1.Focus();
        }
    }
