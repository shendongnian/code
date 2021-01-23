    [TestFixture]
    internal class TimShiftTests
    {
        [Test]
        [TestCase(7, 23.5, 11, 5, 0.5)]
        [TestCase(22, 7.5, 0.5, 1, 8)]
        public void Test(double inputStartHours, double inputEndHours, double expectedRange1Hours, double expectedRange2Hours, double expectedRange3Hours )
        {
            var input = new TimeShift(TimeSpan.FromHours(inputStartHours), TimeSpan.FromHours(inputEndHours));
            var ranges = new List<TimeRange>
            {
                new TimeRange("Range1", TimeSpan.FromHours(7), TimeSpan.FromHours(18)),
                new TimeRange("Range2", TimeSpan.FromHours(18), TimeSpan.FromHours(23)),
                new TimeRange("Range3", TimeSpan.FromHours(23), TimeSpan.FromHours(7))
            };
            var result = new Dictionary<string, TimeSpan>();
            foreach (var range in ranges)
            {
                var time = TimeSpacCalculator.GetTimeSpanIntersect(input, range.Start, range.End);
                result.Add(range.Name, time);
                Console.WriteLine($"{range.Name}: " + time.TotalHours);
            }
            result["Range1"].Should().Be(TimeSpan.FromHours(expectedRange1Hours));
            result["Range2"].Should().Be(TimeSpan.FromHours(expectedRange2Hours));
            result["Range3"].Should().Be(TimeSpan.FromHours(expectedRange3Hours));
    }
