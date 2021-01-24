    adp = new SqlDataAdapter("SELECT 1 FROM Users WHERE Type = @type and username = @username", con);
    adp.SelectCommand.Parameters.Add("@type", "ADMIN");
    adp.SelectCommand.Parameters.Add("@username", loggedInUserName);
    dt = new DataTable(); adp.Fill(dt);
    if (dt.Rows[0][0].ToString() == "1") {
        // Admin
    }
    else {
        // Student
    }
    
