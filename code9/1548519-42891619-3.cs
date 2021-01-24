    public class MyBudget
    {
        void CalcBudget()
        {
            // Do your budget code
        }
    }
    public class GenericBudgetProcessor
    {
        private Action _specificBudget
        public GenericBudgetProcessor(Action specificBudget)
        {
            _specificBudget = specificBudget;
        }
        public void DoTheBudget(Action specificBudget)
        {
            _specificBudget();
        }
    }
