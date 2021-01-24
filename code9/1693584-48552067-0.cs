    var query =
        db.WellnessGroups.Select(wg => new
        {
            wg.WellnessGroupId,
            sum = wg.WellnessGroupUser
                    .Sum(wgu => wgu.Employee.WellnessStepsLogs.Sum(wsl => wsl.StepCount))
        });
