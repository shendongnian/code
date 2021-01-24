    public class Alarm
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public int Repeat { get; set; }
        public Alarm(string name, DateTime time, RepeatWeek repeat)
        {
            this.Name = name;
            this.Time = time;
            this.Repeat = repeat;
        }
        public DateTime GetNext()
        {
            var includeToday = true;
            if (DateTime.Now.TimeOfDay > Time.TimeOfDay)
            {
                includeToday = false;
            }
            var repeat = new RepeatWeek(Repeat);
            var nextDayOfWeek = repeat.GetNextDay(includeToday);
            return MergeDayOfWeekAndTime(nextDayOfWeek, Time);
        }
        private DateTime MergeDayOfWeekAndTime(DayOfWeek? nextDayOfWeek, DateTime Time)
        {
            //Left as exercise to the reader.
            throw new NotImplementedException();
        }
    }
    public class RepeatWeek
    {
        int Repeat;
        public RepeatWeek(int repeat = 0)
        {
            Repeat = repeat;
        }
        public static implicit operator int(RepeatWeek w)
        {
            return w.Repeat;
        }
        public void setDay(DayOfWeek w)
        {
            Repeat |= 1 << (int)w;
        }
        public void removeDay(DayOfWeek w)
        {
            Repeat &= ~(1 << (int)w);
        }
        public static DayOfWeek FollowingDayOfWeek(DayOfWeek day)
        {
            if (day == DayOfWeek.Saturday)
            {
                return DayOfWeek.Sunday;
            }
            else
            {
                return day + 1;
            }
        }
        public DayOfWeek? GetNextDay(bool inclToday = false)
        {
            var inspect = DateTime.Now.DayOfWeek;
            if (inclToday == false)
            {
                inspect = FollowingDayOfWeek(inspect);
            }
            for (int i = 0; i < 7; i++)
            {
                if ((Repeat & (1 << (int)inspect)) > 0) return inspect;
                inspect = FollowingDayOfWeek(inspect);
            }
            return null;
        }
    }
    [TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public void GetNextDayOfWeek()
        {
            var repeat = new RepeatWeek();
            repeat.setDay(DayOfWeek.Monday);
            repeat.setDay(DayOfWeek.Tuesday);
            var expected = DayOfWeek.Monday;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
            {
                expected = DayOfWeek.Tuesday;
            }
            var actual = repeat.GetNextDay();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetNextAlarm()
        {
            //Populate this yourself.
            var alarms = new List<Alarm>();
            var nextAlarm = alarms.Select(a => a.GetNext()).OrderBy(a => a.Ticks).FirstOrDefault();
        }
    }
