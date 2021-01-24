    public class Foo
    {
        public Maybe<Bar> Bar { get; set; }
        public int GetBarCount()
        {
            return Bar.HasValue ? Bar.Count : 0;
        }
    }
    public class Bar
    {
        public int Count { get; set; }
    }
