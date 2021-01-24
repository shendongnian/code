    var query =
        db.WellnessGroup.Select(wg => new {
            wg.WellnessGroupId,
            sum = (int?) wg.WellnessGroupUser
                           .Sum(wgu => wgu.Employee.WellnessStepsLog.Sum(wsl => wsl.StepCount))
        });
