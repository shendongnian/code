    public void PerformLogin(string username, string hashedPassword)
    {
        var user = _repository.GetByPredicate(x => x.Username == username);
        if(user != null)
        {
           if(user.HashedPassword == hashedPassword)
           {
              // Login succeeded do all you need to set usersession here
              return;
           }
        }
        // If we´ve come this far either there is no user or password was incorrect. We need to inform the user that login hasn´t succeeded
       throw new LoginFailedException("Login failed. Username does not exist or password is incorrect.);
    }
