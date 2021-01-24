    private bool button1WasClicked = false; //Kept a variable type of boolean and with a default value false
    
    protected void btnCalculate_Click(object sender, EventArgs e)
    {
       button1WasClicked = true; //If clicked, then true
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       if(button1WasClicked == true) //In the same way, if the button is clicked, then true
       {
            lblMsg.Text = "Done";
       }
       else
       {
            lblMsg.Text = "Please to see total calculation first";
       }
    }
    
