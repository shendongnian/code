    public class CultureInfoFinder
    {
        private static readonly CultureInfo DefaultCulture = new CultureInfo("en-US");
        private static Dictionary<string, CultureInfo> _allSpecificCultures;
        static CultureInfoFinder()
        {
            _allSpecificCultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                .ToDictionary(c => c.ToString(), c => c, StringComparer.InvariantCultureIgnoreCase);
        }
        public static CultureInfo Get(string cultureName)
        {
            CultureInfo c;
            bool knownCulture = _allSpecificCultures.TryGetValue(cultureName, out c);
            return knownCulture ? c : DefaultCulture;
        }
    }
