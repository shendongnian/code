    var q1 =
        from wgu in db.WellnessGroupUser
        from wsl in db.WellnessStepsLog
        where wgu.EmployeeId == wsl.EmployeeId
        group wsl.StepCount by new { wgu.WellnessGroupId, wsl.TrackedDate.Month }
        into g
        select new {g.Key.WellnessGroupId, g.Key.Month, Sum = g.Sum()};
    // join with all WellnessGroups
    var q2 =
        from wg in db.WellnessGroup
        join s in q1 on wg.WellnessGroupId equals s.WellnessGroupId into sj
        from sum in sj.DefaultIfEmpty()
        select new {wg.WellnessGroupId, Month = (int?) sum.Month, Sum = (int?) sum.Sum};
