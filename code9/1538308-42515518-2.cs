    public class CountryComparer : IEqualityComparer<Country>
    {
        public bool Equals(Country x, Country y)
        {
            return x.CountryID == y.CountryID;
        }
        public int GetHashCode(Country obj)
        {
            return obj.CountryID.GetHashCode();
        }
    }
