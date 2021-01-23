    // Load the file to the dictionary
    var loginInfo = File.ReadAllLines("Customer.txt")
    	.Select(i => i.Split(';')) // Lines format: Username;Password
    	.ToDictionary(i => i[0].ToLower(), i => i[1]);  // Username is the key of the dictionary
    
    
    var attempt = 0;
    while (attempt <= 3)
    {
        // prompt the dialog to input login info
    	var userId = txtName.Text;
    	var password = pbPassword.Password;
    	
    	if (loginInfo.ContainsKey(userId) && loginInfo[userId] == password)
    	{
    		// login success, show main window
    	}
    	
        // login fail, increment the count only
        attempt++;
    }
