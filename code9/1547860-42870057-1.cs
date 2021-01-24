        public  class DayStats
        {
            public readonly int[] TotalMinutes = new int[24];
            public void AddWorkRecord(WorkRecord record)
            {
                // Note: this method doesn't handle case when EndTime is next day
                // handle "middle" hours, they are all full
                for (int hour = record.StarTime.Hour + 1; hour < record.EndTime.Hour; hour++)
                {
                    TotalMinutes[hour] += 60;
                }
                // handle first and last hours that might be not full
                if (record.StarTime.Hour == record.EndTime.Hour)
                {
                    TotalMinutes[record.StarTime.Hour] += record.EndTime.Minute - record.StarTime.Minute;
                }
                else
                {
                    TotalMinutes[record.StarTime.Hour] += 60 - record.StarTime.Minute;
                    TotalMinutes[record.EndTime.Hour] += record.EndTime.Minute;
                }
            }
            public string AsPrettyString()
            {
                return string.Join("\n", TotalMinutes
                    .Select((totalMinutes, hour) => string.Format("{0}-{1} {2}", hour, hour + 1, totalMinutes)));
            }
        }
        public class TimeCardAggregate
        {
            private readonly Dictionary<DateTime, DayStats> _days = new Dictionary<DateTime, DayStats>();
            public void AddWorkRecord(WorkRecord record)
            {
                // Note: this method doesn't handle case when EndTime is next day
                var date = record.StarTime.Date;
                DayStats dayStats;
                if (!_days.TryGetValue(date, out dayStats))
                {
                    dayStats = new DayStats();
                    _days.Add(date, dayStats);
                }
                dayStats.AddWorkRecord(record);
            }
            public List<KeyValuePair<DateTime, DayStats>> GetTimecard()
            {
                return _days.ToList().OrderBy(kv => kv.Key).ToList();
            }
        }
