        void Main()
        {
            var data = new List<MyData>();
            data.Add(new MyData() { UtcDT = DateTime.UtcNow, Volume = 1 });
            data.Add(new MyData() { UtcDT = DateTime.UtcNow.AddDays(-1), Volume = 1 });
            data.Add(new MyData() { UtcDT = DateTime.UtcNow.AddDays(-1), Volume = 4 });
            data.Add(new MyData() { UtcDT = DateTime.UtcNow.AddDays(-2), Volume = 5 });
            var result = GroupReportDataAndFormat(data);
        }
        public Dictionary<DateTime, int> GroupReportDataAndFormat(List<MyData> data)
        {
            return data.GroupBy(t => t.UtcDT.Date).ToDictionary(k => k.Key, v => v.Sum(s => s.Volume));
        }
        public class MyData
        {
            public DateTime UtcDT { get; set; }
            public int Volume { get; set; }
        }
