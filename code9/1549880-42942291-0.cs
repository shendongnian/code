    //--------------Form1 code
    
    //declaring addnew object as class level or Method level depends on your design
    //I prefer declaring class level as we can access addnew object properties
    //from anywhere in Form1
    AddNewDownloads addnew;
    
    private void btnAddNewDownload_Click(object sender, EventArgs e)
    {
    	if (addnew == null)
    	{
    		addnew = new AddNewDownloads();
    		addnew.BtnOkClicked += addnew_BtnOkClicked;
    	}
    	
    	addnew.Show();
    }
    
    private void addnew_BtnOkClicked(object sender, EventArgs e)
    {
    	//place your code here to 
    	MessageBox.Show("Event raised by Ok button in AddNewDownloads");
    
    }
    
    
    
    //----------------------AddNewDownloads code
    //declare a class level event
    public event EventHandler BtnOkClicked;
    
    private void btnOK_Click(object sender, EventArgs e)
    {
    	//This will fire an event to be caught by subscriber
    	//which is Form1.. put a break point in 
    	OnGotClosed(new EventArgs());
    	
    	//I am not sure where yo want to put Properties.Settings
    	//So removed it from here... but you can decide and put 
    	//as per your design
    }
    
    protected virtual void OnBtnOkClicked(EventArgs e)
    {
    	EventHandler handler = BtnOkClicked;
    	if (handler != null)
    	{
    		handler(this, e);
    	}
    }
