    class AssemblyNameComparer : IComparer<string>
        {
            private readonly IComparer<string> _baseComparer;
            public AssemblyNameComparer(IComparer<string> baseComparer)
            {
                _baseComparer = baseComparer;
            }
            public int Compare(string x, string y)
            {
                string xTrimmed = RemoveSemicolon(x);
                string yTrimmed = RemoveSemicolon(y);
                return _baseComparer.Compare(xTrimmed, yTrimmed);
            }
            string RemoveSemicolon(string x)
            {
                return Regex.Replace(x, ";", "");
            }
        }
