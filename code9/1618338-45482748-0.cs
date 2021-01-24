    public static class Program
    {
        static void Main(string[] args)
        {
            var myEnumerable = new List<int>() { 1, 2, 3, 4, 5 };
    
            Predicate<int> validator;
            validator = delegate (int item)
            {
                var heavyResult = GetStuff(item);
                return heavyResult.IsSomethingTrue() && heavyResult.IsSomethingElseTrue();
            };
    
            var filtered = myEnumerable.Where(item =>
            item >= 1 ||
            item <= 200 ||
            validator(item) ||
            GetStuff(item).IsAllTrue() ||
            GetStuff(item).IsAllTrueExt()
            );
        }
    
        public static bool IsAllTrueExt(this HeavyResult hr)
        {
            { return hr.IsSomethingTrue() && hr.IsSomethingElseTrue(); }
        }
    
        public static HeavyResult GetStuff(int item)
        {
            return new HeavyResult(item);
        }
    
        public class HeavyResult
        {
            public HeavyResult(int value)
            {
                Value = value;
            }
    
            int Value { get; }
    
            public bool IsSomethingTrue()
            {
                { return Value >= 5; }
            }
    
            public bool IsSomethingElseTrue()
            {
                { return Value <= 50; }
            }
    
            public bool IsAllTrue()
            {
                { return IsSomethingTrue() && IsSomethingElseTrue(); }
            }
    
        }
    }
