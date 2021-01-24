    Array.Sort(data, labels, new DescendingOrderComparer());
    public class DescendingOrderComparer : IComparer<int>
    {
	    public int Compare(int a, int b) => b.CompareTo(a);
    }
