    [HttpPost]
            public string checkLogin([FromBody] Login login)
            {
                getLogin log = new getLogin();
         Boolean check =       log.checkLogin(login);
    
                  if(check == true)
                {
                    return "login done";
                }
                  else
                {
                    return "failed to login";
                }
            }
