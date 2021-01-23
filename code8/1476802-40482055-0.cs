    [TestFixture]
    public class OpenDaysTest
    {
        private readonly OpenDay[] _openDays = new[]
                                                   {
                                                       new OpenDay { DayOfWeek = DayOfWeek.Sunday, IsOpen = true }, 
                                                       new OpenDay { DayOfWeek = DayOfWeek.Monday, IsOpen = true },
                                                       new OpenDay { DayOfWeek = DayOfWeek.Tuesday, IsOpen = false },
                                                       new OpenDay { DayOfWeek = DayOfWeek.Wednesday, IsOpen = false },
                                                       new OpenDay { DayOfWeek = DayOfWeek.Thursday, IsOpen = true },
                                                       new OpenDay { DayOfWeek = DayOfWeek.Friday, IsOpen = true },
                                                       new OpenDay { DayOfWeek = DayOfWeek.Saturday, IsOpen = false }
                                                   };
        
        public string GetNextOpenDayText(DayOfWeek today)
        {
            if (_openDays.All(od => !od.IsOpen))
                throw new Exception("All days are closed");
            var diffDays = 0;
            var index = today;
            DayOfWeek openDay;
            while (true)
            {
                if (_openDays[(int)index].IsOpen)
                {
                    openDay = index;
                    break;
                }
                diffDays++;
                index++;
                if (index > DayOfWeek.Saturday)
                    index = DayOfWeek.Sunday;
            }
            return string.Format("Next open in {0} day{1} on {2}", diffDays, diffDays > 1 ? "s" : string.Empty, openDay);
        }
        [TestCase(DayOfWeek.Monday, "Next open in 0 day on Monday")]
        [TestCase(DayOfWeek.Tuesday, "Next open in 2 days on Thursday")]
        [TestCase(DayOfWeek.Wednesday, "Next open in 1 day on Thursday")]
        [TestCase(DayOfWeek.Thursday, "Next open in 0 day on Thursday")]
        [TestCase(DayOfWeek.Friday, "Next open in 0 day on Friday")]
        [TestCase(DayOfWeek.Saturday, "Next open in 1 day on Sunday")]
        [TestCase(DayOfWeek.Sunday, "Next open in 0 day on Sunday")]
        public void it_should_do(DayOfWeek today, string expected)
        {
            GetNextOpenDayText(today).Should().Be(expected);
        }
    }
    
    internal struct OpenDay
    {
        public DayOfWeek DayOfWeek;
        public bool IsOpen;
    }
