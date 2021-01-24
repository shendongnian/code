        private int NextDay(Schedule jobSchedule)
        {
            var availableSchedules = new[]
            {
                new {Position = 0, Enabled = jobSchedule.Sunday },
                new {Position = 1, Enabled = jobSchedule.Monday },
                new {Position = 2, Enabled = jobSchedule.Tuesday },
                new {Position = 3, Enabled = jobSchedule.Wednesday },
                new {Position = 4, Enabled = jobSchedule.Thursday },
                new {Position = 5, Enabled = jobSchedule.Friday },
                new {Position = 6, Enabled = jobSchedule.Saturday }
            };
            var currentDayOfWeek = (int)DateTime.Now.DayOfWeek;
            var currentPosition = currentDayOfWeek + 1;
            var requiredDays = 1;
            //Optional. incase nothing is enabled
            if (!availableSchedules.Any(x => x.Enabled))
            {
                throw new ArgumentException(nameof(jobSchedule));
            }
            //End Optional. incase nothing is enabled
            do
            {
                var nextSchedule = availableSchedules.First(s => s.Position == currentPosition);
                if (nextSchedule.Enabled)
                {
                    break;
                }
                requiredDays++;
                currentPosition++;
                if (currentPosition > 6) //incase we go to the following week. Reset
                {
                    currentPosition = 0;
                }
            } while (true);
            return requiredDays;
        }
