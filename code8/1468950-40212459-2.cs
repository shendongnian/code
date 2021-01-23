     public static string GetLast7DateString()
     {
         DateTime currentDate = DateTime.Now;
         return String.Join(",",Enumerable.Range(0, 7)
                                          .Select(x => currentDate.AddDays(-x).ToString("dd-MM-yyyy"))
                                          .ToList());
     }
