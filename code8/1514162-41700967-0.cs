    public class CountryData {
        public string Link { get; set; }
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
