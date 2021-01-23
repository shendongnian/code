    int checkedIn = 0;
    string cmdText = @"SELECT TOP 1 CHECKEDIN from timereg 
                       WHERE UNILOGIN = @unilogin";
    string connectionString = ".....";
    using(SqlConnection cnn = new SqlConnection(connectionString))
    using(SqlCommand checkForInOrOut = new SqlCommand(cmdText, cnn))
    {
        cnn.Open();
        cmd.Parameters.Add("@unilogin", SqlDbType.NVarChar).Value = publiclasses.unilogin;
        // You return just one row and one column, 
        // so the best method to use is ExecuteScalar
        object result = cmd.ExecuteScalar();
        // ExecuteScalar returns null if there is no match for your where condition
        if(result != null)
        {
           MessageBox.Show("Login OK");
           
           // Now convert the result variable to the exact datatype 
           // expected for checkedin, here I suppose you want an integer
           checkedIN = Convert.ToInt32(result);
           .....
        }
        else
           MessageBox.Show("Login Failes");
    }
