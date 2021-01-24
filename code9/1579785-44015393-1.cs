    public class MantissaComparer : IComparer<double>
    {
        public int Compare(double x, double y)
        {
            return Comparer<double>.Default.Compare(x - Math.Truncate(x), y - Math.Truncate(y));
        }
    }
