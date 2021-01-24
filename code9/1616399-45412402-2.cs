    void Main()
    {
        var data = new List<MyData>();
        data.Add(new MyData() { UtcDT = DateTime.UtcNow, DayPnl = 1, Positions = 3 });
        data.Add(new MyData() { UtcDT = DateTime.UtcNow.AddDays(-1), DayPnl = 1, Positions = 4 });
        data.Add(new MyData() { UtcDT = DateTime.UtcNow.AddDays(-1), DayPnl = 4, Positions = 5 });
        data.Add(new MyData() { UtcDT = DateTime.UtcNow.AddDays(-2), DayPnl = 5, Positions = 6 });
        var result = GroupReportDataAndFormat(data);
    }
    public Dictionary<DateTime, GroupResult> GroupReportDataAndFormat(List<MyData> data)
    {
        return data.GroupBy(t => t.UtcDT.Date).ToDictionary(
            k => k.Key, v => new GroupResult
            {
                DayPnlSum = v.Sum(s => s.DayPnl),
                Deltas = v.Select(t => t.Positions).Zip(v.Select(s => s.Positions).Skip(1), (current, next) => next - current)
            });
    }
    public class GroupResult
    {
        public double DayPnlSum { get; set; }
        public IEnumerable<double> Deltas { get; set; }
        public int TradeCount
        {
            get
            {
                return Deltas.Where(x => x != 0).Count();
            }
        }
        public int Volume
        {
            get
            {
                return (int)Deltas.Where(x => x != 0).Sum(x => Math.Abs(x));
            }
        }
    }
    public class MyData
    {
        public DateTime UtcDT { get; set; }
        public int DayPnl { get; set; }
        public double Positions { get; set; }
    }
