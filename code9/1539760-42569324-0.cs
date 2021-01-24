    string str = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\charlyn_dale\\Documents\\Visual Studio 2010\\Projects\\LMS\\WindowsFormsApplication2\\Accounts.accdb;Persist Security Info=False");
    using (OleDbConnection conn = new OleDbConnection(str))
    {
        conn.Open();
    
        // security tips: better use parameter names to prevent SQL injection on queries
        // and put value checking method for all textbox values (sanitize input)
        string query = "insert into Account ([Username],[Password],FirstName,MiddleName,LastName,Age,Section,Gender,Address,AccountStatus) values ('" + txt1.Text + "','" + txt2.Text + "','" + txt4.Text + "','" + txt5.Text + "','" + txt6.Text + "','" + txt7.Text + "','" + txt8.Text + "','" + cmb2.Text + "','" + txt9.Text + "','" + cmb1.Text + "')";
        using (OleDbCommand cmd = new OleDbCommand(query, conn))
        {
    	    conn.ExecuteNonQuery();
        }
        ... // other stuff
        conn.Close();
    }
