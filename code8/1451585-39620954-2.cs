    public interface ISummary
    { }
    public class CarSummary : ISummary
    {
        public CarSummary(int someParam)
        {
            
        }
    }
    public interface ISummaryStrategy
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ISummary Create();
    }
    public class CarSummaryStrategy
        : ISummaryStrategy
    {
        public ISummary Create()
        {
            return new CarSummary(42); //The Answer to the Ultimate Question of Life, the Universe, and Everything
        }
    }
    public class Foo
    {
        private Dictionary< Type, ISummaryStrategy > _summaryStrategies;
        public Foo()
        {
            this._summaryStrategies = new Dictionary< Type, ISummaryStrategy >
            {
                {typeof( CarSummary ), new CarSummaryStrategy()}
            };
        }
        public void UseSummaries(Type summary)
        {
            var summaryImpl = this._summaryStrategies[summary].Create();
            // use the summary
        }
    }
