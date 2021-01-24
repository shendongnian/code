    public void DoLogin()
    {
        //Enter Username, company name & Password
        app.EnterText(x => x.Marked("Username"), "annby");
        app.EnterText(x => x.Marked("Company name"), "sara");
        app.EnterText(x => x.Marked("Password"), "sara");
        //Tapping "Sign in" button after submitting user credentials
        app.Tap(x=>x.Text("Sign in"));
    }
    
    [Test]
    public void Login_SuccessfullAuthentication_SuccessfullLogin()
    {
        DoLogin();
    }
    
    [Test]
    public void CreateAppoinment() 
    { 
        DoLogin();
        app.WaitForElement(x => x.Id("action_bar_title"), timeout: TimeSpan.FromSeconds(10));
        app.Tap(x => x.Id("action_bar_title"));
    }
