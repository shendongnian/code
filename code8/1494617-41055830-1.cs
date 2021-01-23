    public class TestItemComparer: IEqualityComparer<TestItem>
    {
        public bool Equals(TestItem x, TestItem y)
        {
            return x.Number == y.Number && x.Something == y.Something;
        }
        public int GetHashCode(TestItem obj)
        {
            return obj.Number ^ obj.Something;
        }
    }
