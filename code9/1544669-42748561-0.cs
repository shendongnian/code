    Dictionary<DateTime, List<int>> dic = new Dictionary<DateTime, List<int>>(DateSecondEqualityComparer.Instance());
    private void timer1_Tick(object sender, EventArgs e)
    {
        List<int> values;
        DateTime currentTime = DateTime.Now;
        if (dic.TryGetValue(currentTime, out values))
        {
            foreach (var value in values)
            {
                ProcessValue(value);
            }
            // If you want to remove the date from the dictionary, uncomment the line below
            // dic.Remove(currentTime);
        }
    }
    private void ProcessValue(int val)
    {
    }
    public class DateSecondEqualityComparer : IEqualityComparer<DateTime>
    {
        public static DateSecondEqualityComparer Instance()
        {
            return new DateSecondEqualityComparer();
        }
        public bool Equals(DateTime x, DateTime y)
        {
            return x.Date == y.Date && x.Hour == y.Hour && x.Minute == y.Minute && x.Second == y.Second;
        }
        public int GetHashCode(DateTime obj)
        {
            // ticks -> seconds
            var seconds = (obj.Ticks / 10000000);
            return seconds.GetHashCode();
        }
    }
