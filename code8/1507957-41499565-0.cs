    StringBuilder message= new StringBuilder("Please fill the following : ");
    if(string.IsNullOrEmpty(txtEYear.Text) 
    {
      message.Append("Year");
    }
    if(string.IsNullOrEmpty(txtECat.Text))
    {
       message.Append("txtECat");
    } 
    if(string.IsNullOrEmpty(txtEID.Text))
    {
       message.Append("ID");
    }
    
    MessageBox.Show(message.ToString());
                   
