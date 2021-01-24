    class ReverseStringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            string a = new string(Regex.Replace(x, "[^a-zA-Z]", "").Reverse().ToArray());
            string b = new string(Regex.Replace(y, "[^a-zA-Z]", "").Reverse().ToArray());
            return a.CompareTo(b);
        }
    }
