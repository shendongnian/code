     if (result == SignInStatus.Success)
     {
          object id = Membership.GetUser().ProviderUserKey
           using(yourdbcontext db = new yourdbcontext())
          {    
          if (db.AspNetUsers.find(id).IsEnabled ==0)
           //....
           }
