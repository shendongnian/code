    string yourConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.accdb; Persist Security";
    using (OleDbConnection conn = new OleDbConnection(yourConnectionString))
    {
        try
        {
            conn.Open();
            using (OleDbCommand cmd = new OleDbCommand("Select * from UsersTable where UName = @Username and Pass = @Password"))
            {
                cmd.Parameters.AddWithValue("@Username", txtUserName.Text);
                cmd.Parameters.AddWithValue("@Password", txtPass.Text);
                using (OleDbDataReader r = cmd.ExecuteReader())
                {
                    if (r.HasRows)
                    {
                        Console.WriteLine("User exists")
                    }
                    else
                    {
                        Console.WriteLine("User exists")   
                    }
                }
            }
            
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.Message);
        }
       }
