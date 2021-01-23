        public LoginPresenter
        {
           // private variables 
    
           public LoginPresenter(ILoginView loginView, IOtherView otherView)
           {
               this.loginView = loginView;
               this.otherView = otherView;
               this.loginView.SignUp += OnSignUp;
           }
           private void OnSignUp(object sender, EventArgs eventArgs)
           {
                if (this.authService.Login(this.loginView.UserName, this.loginView.Password))
                {
                    this.loginView.Close();
                    this.otherView.Show();
                }
           }
        }
