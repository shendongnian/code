    public interface ISummary
    { }
    public class Bar : ISummary
    { }
    public class SummaryFactory
    {
            public static TSummary CreateSummary<TSummary>()
                where TSummary : new()
        {
            return new TSummary();
        }
    }
    public class Foo
    {
        public void AMethod()
        {
            var bar = SummaryFactory.CreateSummary< Bar >();
        }
    }
