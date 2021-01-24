        public class ValueFormatter { }
        public class ValidationRule { }
        public interface ElementSettings
        {
            ValueFormatter Formatter { get; }
            IEnumerable<ValidationRule> GetValidationRules();
        }
        [Test]
        public void Sample()
        {
            var sub = Substitute.For<ElementSettings>();
            var exception = new ArgumentException("alidsfjmlisa");
            sub.When(x => { var tmp = x.Formatter; }).Throw(exception);
            Assert.Throws<ArgumentException>(() =>
            {
                var tmp = sub.Formatter;
            });
        }
