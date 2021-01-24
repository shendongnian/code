    var minciUser = dbContext.MinciUsers.SingleOrDefault(m => m.Id == 1);
    if(minciUser != null)
    {
        // The record with Id 1 has been found. So you can change it's state.
        minciUser.ApplicationUserId = stringUserId;
        // here you will add the rest of the fields you want to update.       
        dbContext.SaveChagnes();
    }
