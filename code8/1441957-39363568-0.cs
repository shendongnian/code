    using (var db = new DataContext())
    {
        List<Report> Reports;
        Reports = db.Reports.Include(report1 => report1.Schedules)
                            .ThenInclude(schedule => schedule.Descriptions)
                        .ToList();
        var report = Reports[0];
        Description newDescription = new Description();
        newDescription.DescriptionId = Guid.NewGuid();
        newDescription.Content = "new content";
        Schedule newSchedule = new Schedule();
        newSchedule.ScheduleId = Guid.NewGuid();
        newSchedule.Title = "new schedule";
        newSchedule.Descriptions = new List<Description>();
        newSchedule.Descriptions.Add(newDescription);
        report.Schedules.Add(newSchedule);
        db.Reports.Update(report);
        db.SaveChanges();
    }
