     public static bool HaveSameItems<T>(this IEnumerable<T> a, IEnumerable<T> b)
            {
                var dictionary = a.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
                foreach (var item in b)
                {
                    int value;
                    if (!dictionary.TryGetValue(item, out value))
                    {
                        return false;
                    }
                    if (value == 0)
                    {
                        return false;
                    }
                    dictionary[item] -= 1;
                }
                return dictionary.All(x => x.Value == 0);
            }
