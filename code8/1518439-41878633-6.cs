    public string GivenUsernameGetUserId(string userName)
    {
        // Use .WaitForNonStaleResultsAsOfNow()
        return ravenSession.Query<User>()
          .Customize(x => x.WaitForNonStaleResultsAsOfNow())
          .Where(u => u.UserName == userName)
          .Select(u => u.Id)
          .FirstOrDefault();
    }
