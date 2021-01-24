    try
    {
        //Logging in.
        var validator = new UNValidator();
        validator.Validate(username, password);
        //Anything written past this point means your login was successful.
    }
    catch
    {
     //Catch the exception here, which means invalid login.
    }
