        static void Main(string[] args)
        {
            foreach (var li in BreakMeDown(5).DistinctBy(JsonConvert.SerializeObject))
                Console.WriteLine(string.Join(", ", li));
        }
        static IImmutableDictionary<int, int> Increment(this IImmutableDictionary<int, int> dict, int i)
        {
            return dict.SetItem(i, dict.TryGetValue(i, out int iCount) ? iCount + 1 : 1);
        }
        public static IEnumerable<IImmutableDictionary<int, int>> BreakMeDown(int n)
        {
            for (int i = 1, j = n - 1; i <= j; i++, j--)
            {
                var iAndJ = ImmutableSortedDictionary.Create<int, int>().Increment(i).Increment(j);
                var bdJ = BreakMeDown(j).Select(bd => bd.Increment(i));
                var bdI = BreakMeDown(i).Select(bd => bd.Increment(j));
                var list = bdI.Concat(bdJ).Concat(new[] { iAndJ });
                foreach (var li in list)
                {
                    yield return li;
                }
            }
        }
