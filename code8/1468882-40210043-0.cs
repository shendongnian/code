    public static class ListShuffle
    {
        private static Random _random = new Random();
        public static IEnumerable<T> ShuffleInPlace<T>(this IList<T> list)
        {
            for (int n = list.Count - 1; n >= 0; n--)
            {
                int randIx = _random.Next(n + 1); // Random int from 0 to n inclusive
                if (randIx != n)
                {
                    T temp = list[randIx];
                    list[randIx] = list[n];
                    list[n] = temp;
                }
                yield return list[n];
            }
        }
        public static IEnumerable<T> Shuffle<T>(this IList<T> list)
        {
            List<int> indices = Enumerable.Range(0, list.Count).ToList();
            foreach (int index in indices.ShuffleInPlace())
            {
                yield return list[index];
            }
        }
    }
