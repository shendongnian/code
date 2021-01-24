    class Recursive
    {
        public static string StrRev(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            var a = s.ToCharArray();
            return new string(CharArrRev(a, 0, a.Length - 1));
        }
        private static char[] CharArrRev(char[] a, int i, int j)
        {
            if (i >= j) return a;
            var c = a[i]; a[i] = a[j]; a[j] = c;
            return CharArrRev(a, i + 1, j - 1);
        }
    }
