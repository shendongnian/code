                foreach (var k in DateList)
            {
                while (Calendar.BlackoutDates.Any(bd => bd.Start.Date == k.Date))
                {
                    Calendar.BlackoutDates.Remove(Calendar.BlackoutDates.FirstOrDefault(bd => bd.Start.Date == k.Date));
                }
            }
