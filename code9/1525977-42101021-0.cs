    A = new IOrderedQueryable<OnDemandHistory>();
    foreach (int id in machineID)
    {
        A.AddRange(OnDemandHistory
         .Where(c => c.MachineID == id).OrderByDescending(c => c.ODHisDate));          
    }
    // order A here
