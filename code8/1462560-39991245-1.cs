    public class AccountState
    {
        public double UpperLimit { get; protected set; }
        public double LowerLimit { get; protected set; }
    }
    public class BronzeState : AccountState
    {
        private BronzeState()
        {
            this.UpperLimit = 5000;
            this.LowerLimit = 1000;
        }
        public static BronzeState GetInstance()
        {
            ...
        }
    }
