    public abstract class RoundingAlgorithm
    {
        public abstract void PerformRounding(IList<Investors> investors, int remainders);
    }
    public class RoundingRandomly : RoundingAlgorithm
    {
        private int someNum;
        private DateTime anotherParam;
        public RoundingRandomly(int someNum, DateTime anotherParam)
        {
            this.someNum = someNum;
            this.anotherParam = anotherParam;
        }
        public override void PerformRounding(IList<Investors> investors, int remainder)
        {
            // ... code ...
        }
    }
    // ... and other subclasses of RoundingAlgorithm
    // ... later on:
    public void Round(IList<Investors> investors, RoundingAlgorithm roundingMethodToUse)
    {
        // ...your other code (checks, etc)...
        
        roundingMethodToUse.Round(investors, remainders);
    }    
