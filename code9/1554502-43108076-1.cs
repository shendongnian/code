    private FUser1 fUser1;
    private FUser2 fUser2;
    private FUser2 fUserAdmin;
    
    private void OpenForm(int userType)
    {
    	switch (userType)
    	{
    		case 1:
    			if (fUser1 == null)
    			{
    				fUser1 = new FUser1();
    				//do initialization specific to FUser1
    				fUser1.txtLogin.Text = "Robinhood";
    			}
    			fUser1.Show();
    			break;
    		case 2:
    			if (fUser2 == null)
    			{
    				fUser2 = new FUser2();
    				//do initialization specific to FUser2
    				fUser2.btnProcess.Enable = false;
    				fUser2.btnPermit.Visible = false;				
    			}
    			fUser2.Show();
    			break;
    		case 3: //Admin
    			if (fUserAdmin == null)
    			{
    				fUserAdmin = new FUser2();
    				//do initialization specific to FUser2
    				fUserAdmin.btnProcess.Enable = true;
    				fUserAdmin.btnPermit.Visible = true;
    				fUserAdmin.ProcessSales(); //Public function in FUser2
    			}
    			fUserAdmin.Show();
    			break;
    	}         
    }
