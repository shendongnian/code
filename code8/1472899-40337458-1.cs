    public static IEnumerable<Activity> GetActivitiesByOrderNumber(List<OrderStuff> orderNumbers)
    {
       List<string> OrderStuffIds = orderNumbers.Select(o => o.Id);
    
        IEnumerable<Activity> activities = Collection.Where(a => OrderStuffIds.Contains(a.Id)).ToList();
        return activity;
    }
