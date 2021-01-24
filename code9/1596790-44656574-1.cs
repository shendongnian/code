    // Execution time: 00:00:00.0140118
    public static IEnumerable<myClass> GetAllJobs(int machineNo)
    {
        var db = new DbContext();
        IEnumerable<myClass> list;
        list = db.vwJobAppointments.Where(a => a.ResourceId == (machineNo)).ToList();
        return list;
    }
    // Execution time: 00:00:00.0019991
    public static IEnumerable<myClass> GetAllJobs2(int machineNo)
    {
        var db = new DbContext();
        IEnumerable<myClass> list;
        list = db.vwJobAppointments.Where(a => a.ResourceId == 55).ToList();
        return list;
    }
    // Execution time: 00:00:00.0010013
    public static IEnumerable<myClass> GetAllJobs3(int machineNo)
    {
        int machineNo2 = machineNo;
        var db = new DbContext();
        IEnumerable<myClass> list;
        list = db.vwJobAppointments.Where(a => a.ResourceId == (machineNo2)).ToList();
        return list;
    }
