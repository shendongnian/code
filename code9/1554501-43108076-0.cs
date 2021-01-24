    private FUser1 fUser1; //fUser1 can access FUser1 public properties in the class
    private FUser2 fUser2; //fUser2 can access FUser2 public properties in the class
    
    private void OpenForm(int userType)
    {
    	switch (userType)
    	{
    		case 1:
    			if (fUser1 == null)
    			{
    				fUser1 = new FUser1();
    				//do initialization specific to FUser1
    				fUser1.txtUser.Text = "Robinhood";
    			}
    			fUser1.Show();
    			break;
    		case 2:
    			if (fUser2 == null)
    			{
    				fUser2 = new FUser2();
    				//do initialization specific to FUser2
    				fUser2.btnProcess.Enable = false;
    			}
    			fUser2.Show();
    			break;
    	}         
    }
