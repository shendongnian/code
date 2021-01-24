        private void SetNightTime()
        {
            DateTime nightTimeStart;
            DateTime nightTimeEnd;
            try
            {
                nightTimeStart = new DateTime(1, 1, 1, 23, 0, 0);
                nightTimeEnd = new DateTime(1, 1, 1, 6, 0, 0);
                if (nightTimeEnd < nightTimeStart)
                    nightTimeEnd = nightTimeEnd.AddDays(1);
                nightTimeIntervals.Add(new DateTimeInterval(nightTimeStart, nightTimeEnd));
                if (nightTimeEnd.Date == nightTimeStart.Date)
                    nightTimeIntervals.Add(new DateTimeInterval(nightTimeStart.AddDays(1), nightTimeEnd.AddDays(1)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
