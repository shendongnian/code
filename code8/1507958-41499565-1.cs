    bool isValidated = true;
    StringBuilder message= new StringBuilder("Please fill the following fields: ");
    if(string.IsNullOrEmpty(txtEYear.Text) 
    {
      message.Append("Year");
      isValidated = false;
    }
    if(string.IsNullOrEmpty(txtECat.Text))
    {
       message.Append("txtECat");
       isValidated = false;
    } 
    if(string.IsNullOrEmpty(txtEID.Text))
    {
      message.Append("ID");
      isValidated = false;
    }
    if(!isValidated)
    {
       MessageBox.Show(message.ToString());
    }
                   
