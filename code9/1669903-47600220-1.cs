    public void Foo()
    {
        try
        {
            var response = SendMyMail();
        }
        catch(Exception e)
        {
            //Show error message to user
        }
    }
    
    public Response SendMyMail()
    {
        emailValidation();
        emailContentLoad();
        emailPlaceholdersLoad();
        return sendEmail();
    }
