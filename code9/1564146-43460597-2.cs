    [TestClass]
    public class MyTestClass {
        [TestMethod]
        public void _ValidateTime() {
            var rules = new List<Rule>()
            {
               new Rule() {From = new TimeSpan(9, 0, 0), To = new TimeSpan(15, 0, 0), Name = "A"},
               new Rule() {From = new TimeSpan(15, 0, 0), To = new TimeSpan(19, 0, 0), Name = "B"},
               new Rule() {From = new TimeSpan(19, 0, 0), To= new TimeSpan(5, 0, 0), Name = "C"}
            };
            var input = TimeSpan.Parse("21:10");
            rules.FirstOrDefault(r => r.Contains(input))
                .Should()
                .NotBeNull()
                .And
                .Match((Rule r) => r.Name == "C");
            input = TimeSpan.Parse("08:10");
            rules.FirstOrDefault(r => r.Contains(input))
                .Should()
                .BeNull();
            input = TimeSpan.Parse("18:10");
            rules.FirstOrDefault(r => r.Contains(input))
                .Should()
                .NotBeNull()
                .And
                .Match((Rule r) => r.Name == "B");
            input = TimeSpan.Parse("10:10");
            rules.FirstOrDefault(r => r.Contains(input))
                .Should()
                .NotBeNull()
                .And
                .Match((Rule r) => r.Name == "A");
        }
