    class StringEqualityComparer : IEqualityComparer<string>
    {
        private CultureInfo _cultureInfo;
        private CompareOptions _options;
        private bool _trim;
        public StringEqualityComparer(CultureInfo cultureInfo,
            CompareOptions options, bool trim)
        {
            _cultureInfo = cultureInfo;
            _options = options;
            _trim = trim;
        }
        public bool Equals(string x, string y)
        {
            if (_trim) { x = x?.Trim(); y = y?.Trim(); }
            return _cultureInfo.CompareInfo.Compare(x, y, _options) == 0;
        }
        public int GetHashCode(string obj)
        {
            if (_trim) obj = obj?.Trim();
            return _cultureInfo.CompareInfo.GetHashCode(obj, _options);
        }
    }
