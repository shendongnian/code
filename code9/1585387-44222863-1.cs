    var retryCount = 3;
    var currentRetry = 0;
    using (var context = new DbContext(ConnectionString))
    {
        var user = context.Set<User>().First(o => o.Id == 1);
        user.Login = "newuserlogin";
        do
        {
            try
            {
                currentRetry++;
                context.SaveChanges();
                break;
            }
            catch (DbUpdateConcurrencyException ex) when (currentRetry <= retryCount)
            {
                //conflict detected
                var entry = ex.Entries.Single();
                //rewrite values from database
                entry.OriginalValues.SetValues(entry.GetDatabaseValues());
            }
        } while (true);
    }
