    protected void radTxb_TextChanged(object sender, EventArgs e)
    { 
        //dothings
        if (!opMsg.IsError)
        {
            RadWizard2_NextButtonClick(sender, null); // arguments WITHOUT types    
        }
    }
