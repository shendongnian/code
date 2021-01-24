    var startDate = new DateTime(2017, 10, 5);
            var endDate = new DateTime(2018, 2, 20);
            var firstDayofMonth = new DateTime(startDate.Year, startDate.Month, 1).AddMonths(1);
            Console.WriteLine(startDate.ToShortDateString());
            while (true)
            {
                var dateToCompare = firstDayofMonth.AddDays(-1);
                //Last month
                if (dateToCompare >= endDate)
                {
                    if (dateToCompare > endDate)
                    {
                        Console.WriteLine(endDate.ToShortDateString());
                    }
                    Console.WriteLine(dateToCompare.ToShortDateString());
                    break;
                }
                if (dateToCompare != startDate)
                {
                    Console.WriteLine(dateToCompare.ToShortDateString());
                }
                firstDayofMonth = firstDayofMonth.AddMonths(1);
            }
