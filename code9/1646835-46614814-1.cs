    from p in plans
    group p by p.Semester into sem
    select new
    {
        Semester = sem.Key,
        Plans = from p in sem
                group p by p.OrderNumber into gp
                select new
                {
                    OrderNUmber = gp.Key,
                    PlansInOrderNumber = 
                        gp.Where(p => !gp.Any(p1 => p1.ModuleStatus == "Completed")
                                   || p.ModuleStatus == "Completed")
                }
    }
