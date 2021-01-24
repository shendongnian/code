    cMIMData = cMIMData.OrderByDescending(x => x.TradeDateTime).ToList();
    startDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 9, 5, 0);
    endDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 13, 0, 0);
                    while (startDate < endDate)
                    {
                        var value = cMIMData.Where(x => x.TradeDateTime.Date == your date &&  x.TradeTime >= startDate.AddMinutes(-5).TimeOfDay &&
                        x.TradeTime <= startDate.TimeOfDay).First();  //get last item value in Limit specified time               
                    startDate = startDate.AddMinutes(5);
                    }
