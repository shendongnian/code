    public DashboardVm GetCounter()
    {
        var vm=new DashboardVm();
        try
        {
            var listofcounters = new List<long>();
            using (var db = new DatabaseContext())
            {
                vm.UserCount = db.User.Select(x => x).Count();
                vm.PendingUserCount = db.User.Count(x => x.IsApproved == false);
                // to do : Set other property values as well
                return vm;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    } 
