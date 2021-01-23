    public override void OnNavigatedTo(NavigationParameters parameters)
    {
        base.OnNavigatedTo(parameters);
        if (parameters.ContainsKey("properties"))
        {
            var localAcs = new List<DetailedActivity>();
            _activities = localAcs;
            var properties = (Dictionary<string, object>)parameters["properties"];
            foreach (var prop in properties)
            {
                if (prop.Value != null)
                    localAcs.Add(new DetailedActivity { Key = prop.Key.ToString(), Value = prop.Value.ToString() });
            }
        }
    }
