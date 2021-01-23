    using System.Collections.Generic;
    public class Program
    {
        public static void Main()
        {
            var lists = new List<List<int>> { new List<int> { 1, 4, 2 }, new List<int> { 3, 4, 5 }, new List<int> { 1, 2, 4 } };
            var dedupe = new List<List<int>>(new HashSet<List<int>>(lists, new MultiSetComparer<int>()));
        }
        public class MultiSetComparer<T> : IEqualityComparer<IEnumerable<T>>
        {
            public bool Equals(IEnumerable<T> first, IEnumerable<T> second)
            {
                if (first == null)
                    return second == null;
                if (second == null)
                    return false;
                if (ReferenceEquals(first, second))
                    return true;
                var firstCollection = first as ICollection<T>;
                var secondCollection = second as ICollection<T>;
                if (firstCollection != null && secondCollection != null)
                {
                    if (firstCollection.Count != secondCollection.Count)
                        return false;
                    if (firstCollection.Count == 0)
                        return true;
                }
                return !HaveMismatchedElement(first, second);
            }
            private static bool HaveMismatchedElement(IEnumerable<T> first, IEnumerable<T> second)
            {
                int firstNullCount;
                int secondNullCount;
                var firstElementCounts = GetElementCounts(first, out firstNullCount);
                var secondElementCounts = GetElementCounts(second, out secondNullCount);
                if (firstNullCount != secondNullCount || firstElementCounts.Count != secondElementCounts.Count)
                    return true;
                foreach (var kvp in firstElementCounts)
                {
                    var firstElementCount = kvp.Value;
                    int secondElementCount;
                    secondElementCounts.TryGetValue(kvp.Key, out secondElementCount);
                    if (firstElementCount != secondElementCount)
                        return true;
                }
                return false;
            }
            private static Dictionary<T, int> GetElementCounts(IEnumerable<T> enumerable, out int nullCount)
            {
                var dictionary = new Dictionary<T, int>();
                nullCount = 0;
                foreach (T element in enumerable)
                {
                    if (element == null)
                    {
                        nullCount++;
                    }
                    else
                    {
                        int num;
                        dictionary.TryGetValue(element, out num);
                        num++;
                        dictionary[element] = num;
                    }
                }
                return dictionary;
            }
            public int GetHashCode(IEnumerable<T> enumerable)
            {
                int hash = 17;
                var list = new List<T>(enumerable);
                list.Sort();
                foreach (T val in list)
                    hash = hash * 23 + ((val == null) ? 42 : val.GetHashCode());
                return hash;
            }
        }
    }
