    // get the objects you want to modify
    var users = context.Users.Where(x => x.Username == myUsername);
    
    foreach (var user in users)
    {
        // change the properties
        user.Bonus += bonusToAdd;
        user.Score += scoreToAdd;
    }
    
    // EF will pick up those changes and save back to the database.
    context.SaveChanges();
