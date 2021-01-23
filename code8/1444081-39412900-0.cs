    var userList = new List<ApplicationUser>();
    foreach (string i in model.SelectedApplicationUserIds)
    {
        userList.Add(new ApplicationUser {Id = i});
    }
    var newCompany = new Company
    {
        Address = model.Address;
        BillingEmail = model.BillingEmail;
        City = model.City;
        // etc. 
        Users = userList
    };
    int response = await context.SaveChangesAsync();
