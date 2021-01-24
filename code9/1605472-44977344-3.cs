    public class MinimumValueCondition : ICondition<SomeClass>
    {
        private readonly int _minimumValue;
        public MinimumValueCondition(int minimumValue)
        {
            _minimumValue = minimumValue;
        }
        public bool CheckCondition(SomeClass subject)
        {
            return subject.Value >= _minimumValue;
        }
    }
