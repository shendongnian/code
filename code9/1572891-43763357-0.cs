    var item = DateTime.Today.AddHours(14); // 14:00:00
    while(item <= DateTime.Today.AddHours(16)) // 16:00:00
    {
        cmb.Items.Add(item.TimeOfDay.ToString(@"hh\:mm"));
        item = item.AddMinutes(20);
    }
