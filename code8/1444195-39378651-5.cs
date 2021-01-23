    public DashboardVm GetCounter()
    {
        var vm=new DashboardVm();
        try
        {
            using (var db = new DatabaseContext())
            {
                vm.UserCount = db.User.Select(x => x).Count();
                vm.PendingUserCount = db.User.Count(x => x.IsApproved == false);
                // TO DO : Set other property values as well              
            }
            return vm;
        }
        catch (Exception ex)
        {
            // to do : Log the error so you know what went wrong
            throw;
        }
    } 
