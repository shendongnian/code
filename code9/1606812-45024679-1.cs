    public class AutoFirstComparer : IComparer<TimeSpanWithType>
    {
        public int Compare(TimeSpanWithType x, TimeSpanWithType y)
        {
            if (x.Type!=y.Type)
            {
                if (x.Type == "auto") return -1;
                if (y.Type == "auto") return 1;
            }
            return x.Time.CompareTo(y.Time);
        }
    }
