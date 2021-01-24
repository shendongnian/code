    var activities = realm.All<ActivityType>().ToArray();
    var ids = new HashSet<string>(data.Select(d => d.id));
    realm.Write(() =>
    {
        foreach (var activity in activities)
        {
            if (!ids.Contains(activity.Id))
            {
                realm.Remove(activity);
            }
        }
    });
