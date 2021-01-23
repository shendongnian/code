    [TestFixture]
    internal class TimShiftTests
    {
        [Test]
        public void Test()
        {
            var ranges = new List<TimeRange>
            {
                new TimeRange("Range1", TimeSpan.FromHours(7), TimeSpan.FromHours(18)),
                new TimeRange("Range2", TimeSpan.FromHours(18), TimeSpan.FromHours(23)),
                new TimeRange("Range3", TimeSpan.FromHours(23), TimeSpan.FromHours(7))
            };
            var input = new TimeShift(TimeSpan.FromHours(7), new TimeSpan(23, 30, 0));
            var result = new Dictionary<string, TimeSpan>();
            foreach (var range in ranges)
            {
                var time = TimeSpacCalculator.GetTimeSpanIntersect(input, range.Start, range.End);
                result.Add(range.Name, time);
                Console.WriteLine($"{range.Name}: " + time.TotalHours);
            }
            result["Range1"].Should().Be(TimeSpan.FromHours(11));
            result["Range2"].Should().Be(TimeSpan.FromHours(5));
            result["Range3"].Should().Be(TimeSpan.FromHours(0.5));
        }
    }
