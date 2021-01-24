    using (var db = new CrmDbContext())
    {
        List<WorkCondition> wc2 = new List<WorkCondition>();
        wc2.Add(db.WorkCondition.Where(wcid => wcid.WorkConditionId == 3).SingleOrDefault());
        wc2.Add(db.WorkCondition.Where(wcid => wcid.WorkConditionId == 1).SingleOrDefault());
    
        var work1 = new Work
        {
            Name = "Tech Play add 2",
            Start = DateTime.Now,
            End = DateTime.Now,
            SalaryMinimum = 2000,
            SalaryMaximum = 3000,
            WorkCondition = wc2
        };
        db.Work.Add(work1);
        db.SaveChanges();
    }
