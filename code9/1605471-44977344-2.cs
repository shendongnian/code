    public class SomeClass
    {
        public int Value { get; set; }
    }
    public class MinimumValueCondition : ICondition<SomeClass>
    {
        public bool CheckCondition(SomeClass subject)
        {
            return subject.Value > 5;
        }
    }
