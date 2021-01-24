    using(var context = new MyDbContext())
    {
        context.People.Add(new Person("John"));
        try
        {
            // using SSMS, manually start a transaction in your db to force a timeout
            context.SaveChanges();
        }
        catch(Exception)
        {
            // catch the time out exception
        }
        // stop the transaction in SSMS
        context.People.Add(new Person("Mike"));
        context.SaveChanges(); // this would cause the exception
    }
