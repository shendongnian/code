    var weekValues = System.Enum.GetValues(typeof(DayofWeekType));
    var weekNames = System.Enum.GetNames(typeof(DayofWeekType));
    for (int i = 0; i <= weekNames.Length - 1 ; i++) {
        ListItem item = new ListItem(weekNames[i], weekValues[i]);
        dropdownlist.Items.Add(item);
    }
