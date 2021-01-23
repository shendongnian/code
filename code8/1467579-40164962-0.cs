    class DataComparer : IEqualityComparer<Data>
    {
        // Datas are equal if their names and Id are equal.
        public bool Equals(Data x, Data y)
        {
            if (ReferenceEquals(x, y))
                return true;
            if (ReferenceEquals(x, null) ||
                ReferenceEquals(y, null))
                return false;
            return x.Id == y.Id && x.Text == y.Text;
        }
        public int GetHashCode(Data data)
        {
            if (ReferenceEquals(product, null))
                return 0;
            return (product.Name == null ? 0 : product.Name.GetHashCode()) ^ product.Code.GetHashCode();
        }
    }
