    public class Country : IEquatable<Country>
    {
        public bool Equals(Country other)
        {
            return other.CountryID == CountryID;
        }
