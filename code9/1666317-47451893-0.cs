    class AssemblyNameComparer : IComparer<string>
        {
            private readonly IComparer<string> _baseComparer;
            public AssemblyNameComparer(IComparer<string> baseComparer)
            {
                _baseComparer = baseComparer;
            }
            public int Compare(string x, string y)
            {
                string xTrimmed = RemoveChars(x);
                string yTrimmed = RemoveChars(y);
                return _baseComparer.Compare(xTrimmed, yTrimmed);
            }
            string RemoveChars(string x)
            {
                return Regex.Replace(x, @"[.;]", "");
            }
        }
