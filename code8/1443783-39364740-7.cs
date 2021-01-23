    List<DateTime> holidayslist = new List<DateTime>();
    holidayslist.Add(new DateTime(2016, 09, 7));
    holidayslist.Add(new DateTime(2016, 09, 8));
    holidayslist.Add(new DateTime(2016, 09, 9));
    
    DateTime start = new DateTime(2016,9,7);
    DateTime ending = CalculateFutureDate(start, 1, holidayslist);
    Console.WriteLine(ending.ToString()); // 12/09/2016 00:00:00
