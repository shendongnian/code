    DateTime date = Convert.ToDateTime(LastVisitLbl.Text);
    if (date.Months < (DateTime.Now.Months - 3))
    {
        // Do Something
    }
