    System.Globalization.CultureInfo pr = new System.Globalization.CultureInfo("fa-ir");
            DateTime dt = DateTime.ParseExact("1396/04/31", "yyyy/MM/dd", pr);
            PersianCalendar pc = new PersianCalendar();
            Console.WriteLine("Today in the Persian Calendar:    {0}, {1}/{2}/{3} {4}:{5}:{6}\n",
                pc.GetDayOfWeek(dt),
                pc.GetYear(dt),
                pc.GetMonth(dt),
                pc.GetDayOfMonth(dt),
                pc.GetHour(dt),
                pc.GetMinute(dt),
                pc.GetSecond(dt));
