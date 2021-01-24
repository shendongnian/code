    if (dt.AsEnumerable().Any( // Check if there is any row meeting criteria
                r =>  r.RowState != DataRowState.Deleted && // row should not be deleted
                      r.Field<string>("FIRSTNAME").Equals(textBox1.Text, StringComparison.CurrentCultureIgnoreCase) && // First name matches ignoring case
                      r.Field<string>("LASTNAME").Equals(textBox2.Text, StringComparison.CurrentCultureIgnoreCase))) // Last name matches ignoring case
    {
        Main ss = new Main(); // Main is the another form which is seen after the successful enterance.
        ss.Show();
    }
    else
    {
        MessageBox.Show("UserName or Password is Wrong");
    }
