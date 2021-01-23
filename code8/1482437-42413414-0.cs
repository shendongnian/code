    private void SubmitLoginForm()
    {
        var useAnotherAccount = Driver.FindElements(By.ClassName("use_another_account")).FirstOrDefault();
    
        if (useAnotherAccount != null)
        {
            useAnotherAccount.Click();
        }
    
        var loginInput = Driver.FindElements(By.Id(Site.Login.UserNameInput)).FirstOrDefault();
    
        if (loginInput != null)
        {
            loginInput.SendKeys(TestingData.UserName);
            loginInput.SendKeys(Keys.Tab);
        }
    
        var passwordInput = Driver.FindElements(By.Id(Site.Login.PasswordInput)).FirstOrDefault();
    
        if (passwordInput != null)
        {
            passwordInput.Clear();
            passwordInput.SendKeys(TestingData.PassWord);
            passwordInput.SendKeys(Keys.Enter);
        }
    
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        wait.Until(f => f.FindElement(By.CssSelector("#cred_sign_in_button:not(.disabled_button")));
    
        var loginButton = Driver.FindElements(By.Id(Site.Login.SigninButton)).FirstOrDefault();
    
        if (loginButton != null)
        {
            loginButton.Click();
            return;
        }
    
        throw new InvalidOperationException("Could not click the login button");
    }
