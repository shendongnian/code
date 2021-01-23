    public class MyDoubleArrComparer : IEqualityComparer<double[]>
    {
        public bool Equals(double[] x, double[] y)
        {
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] != y[i]) return false;
            }
            return true;
        }
        public int GetHashCode(double[] obj)
        {
            return base.GetHashCode();
        }
    }
