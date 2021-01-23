    DateTime day = new DateTime(2016, 1, 15); // Friday
    List<dynamic> collection = new List<dynamic>
    {
        new { CustomerOnboardingId = "Item1", StartDate = new DateTime(2016,1,1) }, // Friday
        new { CustomerOnboardingId = "Item2", StartDate = new DateTime(2016,1,2) },
        new { CustomerOnboardingId = "Item3", StartDate = new DateTime(2016,1,8) }, // Friday
    };
    var result = (from item in collection
                  where item.StartDate.DayOfWeek == day.DayOfWeek
                  select item.CustomerOnboardingId);
    // result = Item1, Item3
