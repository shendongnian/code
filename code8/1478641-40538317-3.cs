    delegate void commandFromChildControlDelegate(string value);
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //add the command to the usercontrol
        commandFromChildControlDelegate command = new commandFromChildControlDelegate(processCommandFromChildControl);
        WebUserControl1.sendCommandToParentControl = command;
    }
    
    //the command invoked from the child control
    private void processCommandFromChildControl(string value)
    {
        Label1.Text = value;
    }
