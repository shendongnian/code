    private void Form1_Load(object sender, EventArgs e)
    {
         DateTime startDate = new DateTime(2017, 05, 1);
         DateTime endDate = new DateTime(2017, 07, 21);
         int weekNoCount = 3; //Every 3rd week
         DayOfWeek[] days = new DayOfWeek[2] { DayOfWeek.Monday, DayOfWeek.Thursday }; //Pass required days here
         FetchTheDays(startDate, endDate, weekNoCount, days);
    }
    private void FetchTheDays(DateTime startDate, DateTime endDate, int weekNoCount, DayOfWeek[] daysofWeek)
    {
         Dictionary<int, DateTime> DictionOfDates = new Dictionary<int, DateTime>();
         TimeSpan tsdiff = endDate - startDate;
         int days = tsdiff.Days; //total #days in the difference from start to end
         for (var i = 0; i <= days; i++)
         {
             var date = startDate.AddDays(i);
             foreach (var weekday in daysofWeek)
             {
                 if (date.DayOfWeek == weekday)
                 DictionOfDates.Add(i, date);
             }
         }
         string testExample = "";
         foreach (var item in DictionOfDates)
         {
             if (item.Key % weekNoCount == 0) //Check remainder is zero when divided by weekCount
             testExample += (item.Value.ToShortDateString() + " (" + item.Value.DayOfWeek + ")" + "\n"); 
         }
         MessageBox.Show(testExample);
    }
