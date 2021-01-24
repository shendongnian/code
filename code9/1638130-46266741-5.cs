    private bool button1WasClicked = false;
    
    protected void btnCalculate_Click(object sender, EventArgs e)
    {
       button1WasClicked = true;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       if(button1WasClicked == true)
       {
            lblMsg.Text = "Done";
       }
       else
       {
            lblMsg.Text = "Please to see total calculation first";
       }
    }
    
