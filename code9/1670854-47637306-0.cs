    using (var context = new MyDbContext())
    
    {
        var activity = context.Activities
                            .Where(a => a.ActivityId == id)
                            .FirstOrDefault<Activity>();
     
       context.Entry(activity).Reference(a => a.User).Load(); // loads User
    
    }
