    //declare the delegates
    private Delegate _sendCommandToParentControl;
    public Delegate sendCommandToParentControl
    {
        set { _sendCommandToParentControl = value; }
    }
    
    //just a button click event handler
    protected void sendCommandToParentControl_Click(object sender, EventArgs e)
    {
        //send the textbox value to the parent by invoking the delegated command
        _sendCommandToParentControl.DynamicInvoke(TextBox1.Text);
    }
