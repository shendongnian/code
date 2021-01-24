    public IMessageBoxService MessageBoxService => this.GetService<IMessageBoxService>();
    public void Islogin()
    {
        if (username.Equals(string.Empty) || password.Equals(string.Empty))
        {
            loginValidation = 0;
        }
        try
        {
            var user = dxdbEntities.UserViews.Where(x => x.username.Equals(username) && x.password.Equals("password"));
            if (user.Count() > 0)
            {
                loginValidation = 1;
                MessageBoxService?.ShowMessage("Success");
            }
            else
            {
                loginValidation = 2;
            }
                   
        }
        catch (Exception)
        {
            loginValidation = 3;
        }
    }
