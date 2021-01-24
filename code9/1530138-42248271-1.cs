    (ids =>
    {
        Func<Bug, int> selector = null;
        IEnumerable<Bug> source = null;
        Action<int> incrementor = null;
        switch (ids.TaskType.ToUpper())
        {
            case "BUGS":
                source = GraphTable._Bugs;
                incrementor = i => TotalBugs + i;   
                break;
            case "TASKS_BUGS":
                source = GraphTable._BugTask;
                incrementor = i => TotalTaskBugs + i; 
                break;
            }
        }
        if (propertyName == "SpentTimeHours")
        {
            selector = b => b.SpenTimeHours;
        }
        else if (propertyName == "RemainingTimeHours")
        {
            selector = b => b.RemainingTimeHours;
        }
        if (selector != null && source != null)
        {
             Incrementor(source.Where(x => x.Aid == ids.Aid)
                               .Select(selector)
                               .FirstOrDefault() ?? 0);
        }
    });
