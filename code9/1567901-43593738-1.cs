    void UpdateCustomerUsers(ICollection<int> ids)
    {
    using (var context = new MyDbContext())
    {
        var customerUsers = context.CustomerUsers.Where(cu => ids.Contains(cu.ID));
     
        foreach (var cu in customerUsers)
        {
            cu.LoginName = cu.LoginName + cu.UserName;
            cu.Modified = DateTime.Now;
            // and so on...
        }
    
        context.SaveChanges();
    }
    }
