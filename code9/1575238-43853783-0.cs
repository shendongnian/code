    if (!int.TryParse(strShipCode, out iShipCode)) {
        iShipCode = 0;
    }
    if (!DateTime.TryParse(strTodayPlusWeek, out dtTodayPlusWeek)) {
        dtTodayPlusWeek = DateTime.Now.AddDays(7);
    }
