    if(String.IsNullOrWhiteSpace(txtbox.Text) || ddlbox.SelectedItem.Text == "Select") 
    {
        string message = "Your Error Message";
        lblControl.Text = message;  
        lblControl.Visible = true;     
        return; // optional   
    }
    else
    {
        save(); //another method to perform insert operation.
    }
