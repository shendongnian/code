    static class SortedListExtensions {
        public static void SortedAdd<T>(this List<T> list, T value) {
            int insertIndex = list.BinarySearch(value);
            if (value < 0) {
                value = ~value;
            }
            list.Insert(insertIndex, value);
        }
        //Added bonus: a faster Contains method
        public static bool SortedContains<T>(this List<T> list, T value) {
            return list.BinarySearch(value) >= 0;
        }
    }
    
    List<int> values = new List<int>();
    values.SortedAdd(3);
    values.SortedAdd(1);
    values.SortedAdd(2);
