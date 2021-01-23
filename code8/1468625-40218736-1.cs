    var matchingUserNames = db.Users
        .Where(user => user.email == useremail)
        .Select(user => new
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
        });
    foreach (var matchingUserName in matchingUserNames)
    {
        Console.WriteLine(matchingUserName.FirstName + ' ' 
            + matchingUserName.LastName);
    }
