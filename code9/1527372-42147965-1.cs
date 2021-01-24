    //declare a variable to on the new page for the passed id
    int Ownerid = new int();
    
    //check if the querystring exists
    if (Request.QueryString["User"] != null)
    {
        //wrap the conversion in a try-catch blok because in a querystring a user can change the value
        try
        {
            //convert the querystring to a usable value
            Ownerid = Convert.ToInt32(Request.QueryString["User"]);
        }
        catch
        {
        }
    }
