    [TestClass]
    public class TimeShiftTests : MiscUnitTests {
        [TestMethod]
        public void TimeShiftDurationTest() {
            var shifts = new List<string>(){
                "07:00 - 18:00",
                "18:00 - 23:00",
                "23:00 - 07:00"
            }.Select(s => ParseShift(s));
            var timeShift = "07:00 - 23:30";
            var totalExpectedHours = 16.5;
            var input = ParseShift(timeShift);
            var intersections = shifts
                .Select(shift => shift.GetIntersection(input))
                .ToArray();
            intersections.Length.Should().Be(3);
            var actualHours = intersections.Select(range => (range.Maximum - range.Minimum).TotalHours).ToArray();
            var totalActualHours = actualHours.Sum();
            totalActualHours.Should().Be(totalExpectedHours);
            actualHours[0].Should().Be(11);
            actualHours[1].Should().Be(5);
            actualHours[2].Should().Be(0.5);
        }
        private IRange<DateTime> ParseShift(string period, string format = "HH:mm") {
            var tokens = period
                .Split(new[] { "to", "-" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim().Replace(" ", string.Empty))
                .ToArray();
            if (tokens.Length != 2) throw new FormatException("time period not well formatted");
            var startDate = DateTime.ParseExact(tokens[0], format, CultureInfo.InvariantCulture);
            var stopDate = DateTime.ParseExact(tokens[1], format, CultureInfo.InvariantCulture);
            var beginTime = startDate.TimeOfDay;
            var endTime = stopDate.TimeOfDay;
            if (endTime < beginTime) {
                stopDate = stopDate.AddDays(1);
            }
            return Range.Of(startDate, stopDate);
        }
    }
