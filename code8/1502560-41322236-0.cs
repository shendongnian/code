    public static class ListExtensions {
        public static List<T> GetRange<T>(this List<T> list, int start) {
            return list.GetRange(start, list.Count - start);
        }
    }
    var remaining = list.GetRange(7);
