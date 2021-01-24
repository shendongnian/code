    public class CompareIPInfo_By_IPEndInt : IComparer<IPInfo> {
        public int Compare(IPInfo x, IPInfo y) {
            return x.IPEndInt.CompareTo(y.IPEndInt);
        }
    }
