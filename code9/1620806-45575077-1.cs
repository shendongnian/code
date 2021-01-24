        public static string FindNthItem(List<string> list, string search, int n)
        {
            var results = list.Where(x => x.StartsWith(search));
            if (n > results.Count || n < 0)
                return null;
            else
                return results.ElementAt(n);
        }
