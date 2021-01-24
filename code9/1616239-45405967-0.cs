    string firstName;
    string lastName;
    if (Page.PreviousPage != null)
    {
        TextBox srcFirstName= 
            (TextBox)Page.PreviousPage.FindControl("firstName");
        if (srcFirstName!= null)
        {
            firstName = srcLastName.Text;
        }
        TextBox srcLastName= 
            (TextBox)Page.PreviousPage.FindControl("lastName");
        if (srcLastName!= null)
        {
            lastName = srcLastName.Text;
        }
    }
