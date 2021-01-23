            var weekDay = 0;
            var dates = new List<DateTime>();
            for (int i = 0; i < days; i++)
            {
                if ((int)date.AddDays(i).DayOfWeek == weekDay)
                {
                    dates.Add(date.AddDays(i));
                }
            }
