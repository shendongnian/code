    private bool inhibit = true;
    private void doSomeProcessWithInhibit()
    {
        try
        {
            inhibit = true;
       
            // processing comes here    
        }
        // if something goes wrong, make sure other functionality is not blocked
        finally
        {
            inhibit = false;
        }
    }
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // fast return to reduce nesting
        if (inhibit)
            return;
        // do event handling stuff here
    }
