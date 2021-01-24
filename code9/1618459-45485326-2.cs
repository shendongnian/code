    DateTime date;
    if (DateTime.TryParse(LastVisitLbl.Text, out date)
    {
         if (date < DateTime.Now.AddMonths(-3))
         {
              // Do Something
         }
    }
    else
       // Error - the label's format is not a correct DateTime
