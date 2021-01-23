    public abstract class AccountState
    {
        public abstract double UpperLimit { get; }
        public abstract double LowerLimit { get; }
    }
    public class BronzeState : AccountState
    {
        public override double UpperLimit
        {
            get { return 5000; }
        }
        
        public override double LowerLimit
        {
            get { return 1000; }
        }
        public static BronzeState GetInstance()
        {
            ...
        }
    }
