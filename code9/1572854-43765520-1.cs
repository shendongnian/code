    // Base form
    protected virtual void Close()
    {
        // Base logic
    }
    private void CloseButton_Click(object sender, EventArgs e)
    {
        Close();
    }
    // In derived form - just override "Close" method
    protected override void Close()
    {
       // custom logic - will be executed when "Close" button clicked
    }
   
