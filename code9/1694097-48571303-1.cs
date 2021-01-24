    // define the query - and I'd recommend to always define the name of the columns you're inserting into
    string query = "INSERT INTO dbo.Staff_Management(name-of-column-here) VALUES (@Birthdate);";
    
    // define connection and command
    // also: do **NOT** use the `sa` user for your production code! 
    using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=sms;Persist Security Info=True;User ID=sa;Password=pass"))
    using (SqlCommand cmd = new SqlCommand(query, con))
    {
        // add the parameter - and use the proper datatype - don't convert all dates to strings all the time!
        cmd.Parameters.Add("@Birthdate", SqlDbType.Date).Value = TM_Add_Birthdate.Value;
    
        // open connection, execute INSERT query, close connection - done
        con.Open();	
        cmd.ExecuteNonQuery();
        con.Close();
    
        MessageBox.Show("Data saved successfully");
    }
