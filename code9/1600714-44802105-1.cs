    model = model.Where(x=> {
        var timeOfDay = DateTime.Parse(x.UpdatedTime).TimeOfDay; 
        return x.status=="UP" && 
            (timeOfDay.TotalHours >= 20 ||  timeOfDay.TotalHours < 6);
        })
        .OrderByDescending(x => DateTime.Parse(x.UpdatedTime)).Take(100).ToList();
