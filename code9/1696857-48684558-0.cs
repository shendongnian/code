    public class ChildClassTestable : ChildClass
    {
        public int SumOfParentReturnValue { set; get; }
        public override int Sum()
        {
            return 1 + SumOfParentReturnValue;
        }
    }
