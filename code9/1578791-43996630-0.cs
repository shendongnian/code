    public async Task<TapkeyUser> ValidateCredentialsAsync(string username, string password)
    {
          //This is pseudo-code implement your DB logic here
          if (database.query("select id from users where username = username and password = password") 
          {
               return new User(); //return User from Database here 
          } else {
               return null;
          }        
    }
