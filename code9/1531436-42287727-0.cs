        string condense = "datasource=localhost;port=3306;username=root;password=''";
        string milk = "insert into empaccount.empinfo(IDNUMBER,email,username,password,firstname,lastname,cnumber) values ('" + this.idnumber.Text + "','" + email.Text + "','" + username.Text + "','" + password.Text + "','" + firstname.Text + "','" + this.lastname.Text + "','" + contactno.Text + "');";
        MySqlConnection conDatabase = new MySqlConnection(condense);
        MySqlCommand cmdDatabase = new MySqlCommand(milk, conDatabase);
        MySqlDataReader myReader;
        if (string.IsNullOrEmpty(idnumber.Text))
        {
            idnumber.Text = " Please generate an id number";
        }
        else
        {
          conDatabase.Open();
          try {
            cmdDatabase.ExecuteNonQuery();
          }
          catch {
            //Username is taken
          }
          MessageBox.Show("You're Registered!", "Successful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
         }
