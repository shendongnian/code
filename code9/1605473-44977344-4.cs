    public class Condition<T> : ICondition<T>
    {
        private readonly Func<T, bool> _conditionFunction;
        public Condition(Func<T, bool> conditionFunction)
        {
            _conditionFunction = conditionFunction;
        }
        public bool CheckCondition(T subject)
        {
            return _conditionFunction(subject);
        }
    }
