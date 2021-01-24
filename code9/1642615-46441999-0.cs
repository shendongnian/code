    if (ValidateForm())
    {
       if(CheckDulicate() == false)
       {
           Save();
       }
       else
       {
           // display the message you want
           // MessageBox.Show("....");
       }
    }
