    [TestFixture]
    public class DateTimeScheduleTests
    {
        public double GetScheduledHours(DateTime begin, DateTime end)
        {
            var beginIsDaylight = begin.IsDaylightSavingTime();
            var endIsDayLight = end.IsDaylightSavingTime();
            var diff = 0;
            if (beginIsDaylight ^ endIsDayLight)
                diff = beginIsDaylight ? -1 : 1;
            return (begin - end).TotalHours + diff;
        }
        [Test]
        public void TestDate()
        {
            var begin = new DateTime(2016, 10, 30);
            var end = new DateTime(2016, 10, 29);
            GetScheduledHours(begin, end).Should().Be(24);
            begin = new DateTime(2016, 10, 31);
            end = new DateTime(2016, 10, 30);
            GetScheduledHours(begin, end).Should().Be(25);
            begin = new DateTime(2017, 3, 26);
            end = new DateTime(2017, 3, 25);
            GetScheduledHours(begin, end).Should().Be(24);
            begin = new DateTime(2017, 3, 27);
            end = new DateTime(2017, 3, 26);
            GetScheduledHours(begin, end).Should().Be(23);
        }
    }
