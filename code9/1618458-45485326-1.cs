    DateTime date;
    DateTime.TryParse(LastVisitLbl.Text, date);
    if (date < DateTime.Now.AddMonths(-3))
    {
        // Do Something
    }
