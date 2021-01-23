    [DebuggerDisplay("{ToString()}")]
    public class ListOfInts : List<int>
    {
        public override string ToString()
        {
            return string.Join(",", this);
        }
    }
