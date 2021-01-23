    [Test, Description("Create Account"), Category("Account")]
    public void ResponseMessageShouldEqualsOk()
    {        
       Assert.That (res.ResponseStatus.Message, Is.EqualTo("OK"), "Account was not created");
    }
    [Test, Description("Create Account"), Category("Account")]
    public void UserNameShouldEqualsName()
    {        
       Assert.That (res.User.Name, Is.EqualTo("Name"));
    }
    [Test, Description("Create Account"), Category("Account")]
    public void UserNationalityShouldEqualsUS()
    {        
       Assert.That (res.User.Nationality, Is.EqualTo("US"));
    }
