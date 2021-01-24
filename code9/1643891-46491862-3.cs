    var outsideShifts = dbContrxt.CustomerActions
        .Where(a => a.ActionType == 2 || a.ActionType == 4)
        .Where(a => a.Worker.Shifts.All(s => a.ArrivalTime < s.ShiftStart ||
                                             a.ArrivalTime > s.ShiftEnd))
        .GroupBy(a => new 
        { 
            WorkerId = a.Worker.Id,
            WorkerName = a.Worker.Name
        })
        .Select(g => new
        {
            WorkerId = g.Key.WorkerId,
            WorkerName = g.Key.WorkerName,
            ShiftId = null,
            ShiftStart = null,
            ShiftEnd = null,
            CustomerActions = g.ToList()
        });
