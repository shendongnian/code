    try
    {
        // ask whether it is blank or full of spaces
        if (string.IsNullOrWhiteSpace(tFN.Text))
        {
            lblMessage.Text = "Name can't be Blank";
        }
        else 
        {
            person.FirstName = tFN.Text;
        }
        // do the same again for the last name
        if (string.IsNullOrWhiteSpace(tLN.Text))
        {
            lblMessage.Text = "Name can't be Blank";
        }
        else 
        {
            person.FirstName = tLN.Text;
        }
        // use TryParse for the age
        int p_age;
        if (Int.TryParse(tAge.Text, out p_age))
        {
            person.Age = p_age;
        }
        else 
        {
            lblMessage.Text = "Age is in incorrect Format";
        }
       ....
