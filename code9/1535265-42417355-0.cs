    public class MatrixComparer : IEqualityComparer<Matrix>
    {
        public bool Equals(Matrix x, Matrix y)
        {
            if (x.Column.Count != y.Column.Count) return false;
            return !x.Column.Where((t, i) => t != y.Column[i]).Any();
        }
        public int GetHashCode(Matrix obj)
        {
            return obj.Column.Aggregate((i1, i2) => i1 ^ i2);
        }
    }
