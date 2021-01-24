    if(String.IsNullOrWhiteSpace(txtbox.Text) || ddlbox.SelectedItem.Text == "Select") 
    {
        string message = "Your Error Message";
    
        ModelState.AddModelError("", message);     
    
        return;   
    }
    else
    {
        save(); //another method to perform insert operation.
    }
