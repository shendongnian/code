    A = new List<OnDemandHistory>();
    foreach (int id in machineID)
    {
        A.AddRange(OnDemandHistory
         .Where(c => c.MachineID == id).OrderByDescending(c => c.ODHisDate).ToList());          
    }
    // order A here
