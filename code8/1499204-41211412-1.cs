    public class Things : IComparable<Things>
    {
        public string Item = "";
        int IComparable<Things>.CompareTo(Things other)
        {
            return this.Item.CompareTo(other.Item);
        }
    }
