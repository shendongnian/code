    [HttpPost]
    public string checkLogin(string username, string password)
    {
      Login login = new Login();
      login.username = username;
      login.password = password;
      getLogin log = new getLogin();
      Boolean check = log.checkLogin(login);
      if(check == true)
      {
        return "login done";
      }
      else
      {
        return "failed to login";
      }
    }
