    private bool button1WasClicked = false;
    
    protected void button1_Click(object sender, EventArgs e)
    {
        button1WasClicked = true;
    }
    protected void btnCalculate_Click(object sender, EventArgs e)
    {
       if(button1WasClicked == true)
       {
            lblMsg.Text = "Done";
       }
       else
       {
            lblMsg.Text = "Please click here to see total calculation first";
       }
    }
    
