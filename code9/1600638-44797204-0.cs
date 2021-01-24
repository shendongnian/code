    bool found = false;
    for (int i = 0; i < dt.Rows.Count; i++)
    {
        if (textBox1.Text == dt.Rows[i]["FIRSTNAME"].ToString().ToLower() && textBox2.Text == dt.Rows[i]["LASTNAME"].ToString().ToLower())
        {
           found = true;
           break;
        }
    }
    
    if (found)
    {
        Main ss = new Main(); // Main is the another form which is seen after the successful enterance.
        ss.Show();
    }
    else 
    {
        MessageBox.Show("UserName or Password is Wrong");
    }
