    Adduser adduser = new Adduser();
    adduser.passwordProfile = new PasswordProfile() 
    {
        password = "TestClassUser",
        forceChangePasswordNextLogin = false
    };
    adduser.signInNames = new Signinname[2] {
        new Signinname() 
        {
            type = "userName",
            value = "TestClassUser"
        },
        new Signinname()
        {
            type = "emailAddress",
            value = "TestClassUser@Test.com"
        }
    };
