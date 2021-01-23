    string userName = tbLogin.Text;
    string password = tbPassword.Password;
    bw.DoWork += (o, args) =>
    {   
       user = _viewmodel.Login(userName, password); 
    };
