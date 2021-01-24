    var plansQuery = 
    from p in _sqLiteAsyncConnection.Table<CoursePlan>()
    group p by p.Semester into sem
    select new
    {
        PlansInSemester = 
            from p in sem
            group p by p.OrderNumber into gp
            select new
            {
                PlansInOrderNumber =
                    gp.Where(p => !gp.Any(p1 => p1.ModuleStatus == "Completed")
                               || p.ModuleStatus == "Completed")
            }
    };
