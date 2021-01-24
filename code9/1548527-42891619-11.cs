    public class MyBudget
    {
        int _budgetId;
        int _deptId;
        public MyBudget(int budgetId, int deptId) 
        {
             _budgetId = budgetId;
             _deptId = deptId;
        }
        void CalcBudget()
        {
            // Do your budget code using _budgetId and _deptId
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
