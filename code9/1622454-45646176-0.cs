    [TestClass]
    public class GroupByDateIntervalsTests {
        [TestMethod]
        public void Group_By_5_year_Intervals_Max_30() {
            var employees = GenerateRandomDates(DateTime.Now, 5, 40, 50).Select((d, i) => new { id = i, StartDate = d });
            var now = DateTime.Today;
            var period = 5;
            var maxPeriod = 30;
            var groups = from employee in employees
                         let interval = DateTime.MinValue.AddDays((now - employee.StartDate).TotalDays).Year / period
                         group employee by Math.Min(interval * period, maxPeriod) into g
                         orderby g.Key
                         select new {
                             period = g.Key,
                             employees = g.Select(e => e.id).ToArray()
                         };
            var result = groups.ToList();
        }
        [TestMethod]
        public void Group_By_Random_Interval_Max_30() {
            var employees = GenerateRandomDates(DateTime.Now, 5, 40, 50).Select((d, i) => new { id = i, StartDate = d });
            var now = DateTime.Today;
            var periods = new[] { 5, 10, 20, 30 };
            var groups = employees
                .GroupBy(employee => {
                    var period = DateTime.MinValue.AddDays((now - employee.StartDate).TotalDays).Year;
                    var interval = periods.Where(p => (period / p) > 0).Max();
                    return Math.Min(interval, periods.Max());
                })
                .Select(g => new {
                    period = g.Key,
                    employees = g.Select(e => e.id).ToArray()
                });
            var result = groups.ToList();
        }
        public List<DateTime> GenerateRandomDates(DateTime rootDate, int minAgeAtRootDate, int maxAgeAtRootDate, int count) {
            Contract.Assert(minAgeAtRootDate <= maxAgeAtRootDate, "invalid age range. Minimum age cannot be higher than maximum age");
            var minDate = rootDate.Date.AddYears(-maxAgeAtRootDate);
            var maxDate = rootDate.Date.AddYears(-minAgeAtRootDate);
            var range = (maxDate - minDate).Days;
            if (range == 0) {
                range = 364;
            }
            var random = new Random();
            var dates = Enumerable
                .Range(1, count)
                .Select(i => minDate.AddDays(random.Next(range)))
                .ToList();
            return dates;
        }
    }
