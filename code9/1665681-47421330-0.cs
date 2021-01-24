    public static class Ext {
        static public bool ContainsAll<T, TKey>(this List<T> containingList, List<T> containee, Func<T, TKey> key) {
            var HSContainingList = new HashSet<TKey>(containingList.Select(key));
            return containee.All(l2p => HSContainingList.Contains(key(l2p)));
        }
        static public bool ContainsAll<T>(this List<T> containingList, List<T> containee) => containingList.ContainsAll(containee, item => item);
    }
