    Func<Bug, int> selector = null;
    IEnumerable<Bug> source = null;
    switch (ids.TaskType.ToUpper())
    {
        case "BUGS":
            source = GraphTable._Bugs   
            break;
        case "TASKS_BUGS":
            source = GraphTable._BugTask
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
        return source.Where(x => x.Aid == ids.Aid)
                     .Select(selector)
                     .FirstOrDefault() ?? 0;
    return //whatever
