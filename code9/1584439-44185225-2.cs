    class IatEqualityComparer : IComparer<string>
    {
        public int Compare(string a, string b)
        {
            if (a == b)
                return 0;
            var aWithoutExtension = Path.GetFileNameWithoutExtension(a);
            var bWithoutExtension = Path.GetFileNameWithoutExtension(b);
            var aIsIat = aWithoutExtension.EndsWith("IAT", StringComparison.InvariantCultureIgnoreCase);
            var bIsIat = bWithoutExtension.EndsWith("IAT", StringComparison.InvariantCultureIgnoreCase);
            if (aIsIat && !bIsIat)
                return 1;
            if (!aIsIat && bIsIat)
                return -1;
            return a.CompareTo(b);
        }
    }
