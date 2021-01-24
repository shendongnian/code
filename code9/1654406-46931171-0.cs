        private static readonly Random Random = new Random();
        private static readonly object Sync = new object();
        public static IEnumerable<T> RandomElements<T>(this IEnumerable<T> enumerable, int amount, Func<T, bool>  filter)
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException(nameof(enumerable));
            }
            var filtered = enumerable.Where(filter).ToList();
            var take = Math.Min(filtered.Count, amount);
            for (var i = 0; i < take; i++)
            {
                lock (Sync)
                {
                    var randomIndex = Random.Next(filtered.Count);
                    yield return filtered.ElementAt(randomIndex);
                }
            }
        }
