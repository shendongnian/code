    public static IEnumerable<Activity> GetActivitiesByOrderNumber(List<Activity> activities)
    {
         IEnumerable<Activity> activity = Collection.Find<Activity>(o => activities.Contain(o)).ToList();
         return activity;
    }
