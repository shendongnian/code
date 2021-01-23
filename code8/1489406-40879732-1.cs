    Dictionary<string, string> loginInfo;
    short attempts = 0;
    public UserAndPin()
    {
        InitializeComponent();
        // Load the file to the dictionary
        loginInfo = File.ReadAllLines("Customer.txt")
    	    .Select(i => i.Split(';')) // Lines format: Username;Password
    	    .ToDictionary(i => i[0].ToLower(), i => i[1]);  // Username is the key of the dictionary
       
    }
    
    private void btnOK_Click(object sender, RoutedEventArgs e)
    {    
    	var userId = txtName.Text.ToLower(); // Username ignore case
    	var password = pbPassword.Password;
    	
    	if (loginInfo.ContainsKey(userId) && loginInfo[userId] == password)
    	{
    		// login success, show main window
			MainWindow mainWindow = new MainWindow();
			this.Hide();
			mainWindow.ShowDialog();
    	}
    	
    	// login fail, increment the count only
    	attempt++;
        if (attempts < 3)
		{
			MessageBox.Show("The NAME or PIN is incorect, you have " + (3 - attempts) + " attemps more");                                                    
		}
		if (attempts == 3)
		{
			MessageBox.Show("Please try again later");
			this.Close();
		}   
    }
