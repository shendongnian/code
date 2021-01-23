    public class CountryData : IEquatable<CountryData>{
        public string Link { get; set; }
        public bool Equals(CountryData other) {
            if (other == null) {
                return false;
            }
            return StringComparer.Ordinal.Equals(Link , other.Link);
        }
        public override int GetHashCode() {
            return Link.GetHashCode();
        }
    }
    public static class Country {
        public static readonly Europe Europe = new Europe();
    }
    public class Europe : IEnumerable<CountryData> {
        private List<CountryData> All => new List<CountryData> {
            Austria,
            Belgium
        };
        public CountryData Austria = new CountryData { Link = @"\Country\Austria" };
        public CountryData Belgium = new CountryData { Link = @"\Country\Belgium" };
        IEnumerator<CountryData> IEnumerable<CountryData>.GetEnumerator() {
            return All.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return All.GetEnumerator();
        }
    }
