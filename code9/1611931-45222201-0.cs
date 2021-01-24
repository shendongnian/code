    DateTime startDate = new DateTime(2017, 05, 1);
    DateTime endDate = new DateTime(2017, 07, 21); 
    Dictionary<int, string> DictionOfDates = new Dictionary<int, string>();
    int weekNoCount = 3; //Every 3rd week
    TimeSpan tsdiff = endDate - startDate;
    int days = tsdiff.Days; //total #days in the difference from start to end
    for (var i = 0; i <= days; i++)
    {
        var date = startDate.AddDays(i);
        switch (date.DayOfWeek)
        {                
          case DayOfWeek.Monday:
               DictionOfDates.Add(i, date.ToShortDateString());
               break;
        }
    }
    foreach (var item in DictionOfDates)
    {
       if (item.Key % weekNoCount == 0) //Check remainder is zero when divided by weekCount
           MessageBox.Show(item.Value); //prints the date which you want after the n'th week check
    }
