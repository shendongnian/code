    // Button click event
    private void btnDisableAcc_Click(object sender, EventArgs e)
    {
    	// When the user clicks the button
    	String _ADUserName = textBox1.Text; // <-- The textbox you enter your username?
    
    	// Call the method below 'DiableADUserUsingUserPrincipal'
    	DiableADUserUsingUserPrincipal(_ADUserName); // <-- Pass in the user name via the local variable
    }
    
