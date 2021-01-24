        static void Main(string[] args)
        {
            var MainBookmarksList = new List<DateTime>();
            MainBookmarksList.Add(new DateTime(1900, 1, 1, 12, 0, 5));
            MainBookmarksList.Add(new DateTime(1900, 1, 1, 12, 0, 10));
            MainBookmarksList.Add(new DateTime(1900, 1, 1, 12, 0, 15));
            MainBookmarksList.Add(new DateTime(1900, 1, 1, 12, 30, 15));
            MainBookmarksList.Add(new DateTime(1900, 1, 1, 12, 30, 25));
            var interval = new TimeSpan(0, 0, 15);
            var groupedTimes = new List<TimeGroup>();
            var currentTimeGroup = new TimeGroup(MainBookmarksList[0]);
            groupedTimes.Add(currentTimeGroup);
            for (var i = 1; i < MainBookmarksList.Count; i++)
            {
                var time = MainBookmarksList[i];
                if (time-currentTimeGroup.Begin > interval)
                {
                    currentTimeGroup = new TimeGroup(time);
                    groupedTimes.Add(currentTimeGroup);
                }
                else
                {
                    currentTimeGroup.Values.Add(time);
                }
            }
        }
        class TimeGroup
        {
            public TimeGroup(DateTime dateTime)
            {
                Begin = dateTime;
                Values = new List<DateTime>() { dateTime };
            }
            public DateTime Begin { get; }
            public List<DateTime> Values { get; }
        }
