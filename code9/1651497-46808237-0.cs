    SqlConnection con = new SqlConnection();
    con.ConnectionString = @"Data Source =.; Initial Catalog = master; Integrated Security = True;";
    con.Open();
    
    string str = "USE master;" +
    "ALTER DATABASE PhoneBookDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE; EXEC sp_detach_db @dbname = N'PhoneBookDB'";
    
    SqlCommand cmd = new SqlCommand(str, con);
    cmd.ExecuteNonQuery();
    con.Close();
    MessageBox.Show("Detached", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        Application.Exit();
