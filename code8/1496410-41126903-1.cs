    // first get DbContext from the Owin.
    var context = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
    
    foreach (AppUser appUser in LegacyUsers){
        var user = UserManager.FindByName(appUser.userName);
        if (user != null){
            If (!user.Email.Equals(appUser.Email)){
                var result = UserManager.setEmail(user.Id, appUser.Email)
                if (!result.Succeeded){                
                    Log.Error(…);
                    // detach the user then proceed to the next one 
                    context.Entry(user).State = EntityState.Detached;
                    continue;
                }
            }
        }
        else{
            // rest of the code
        }
    }
   
