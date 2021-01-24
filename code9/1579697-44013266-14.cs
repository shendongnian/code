    public static class ListExtensions
    {
        public static void Splice<T>(this List<T> list, int insertAtIndex,
            List<T> items)
        {
            list.Splice(insertAtIndex, items, 0, items.Count);
        }
        public static void Splice<T>(this List<T> list, int insertAtIndex,
            List<T> items, int itemIndex)
        {
            list.Splice(insertAtIndex, items, itemIndex, itemIndex + 1);
        }
        public static void Splice<T>(this List<T> list, int insertAtIndex, 
            List<T> items, int firstIndexInclusive, int lastIndexExclusive)
        {
            if (items == null) return;
            insertAtIndex = Math.Min(list.Count, Math.Max(0, insertAtIndex));
            firstIndexInclusive = Math.Min(items.Count - 1, Math.Max(0, firstIndexInclusive));
            lastIndexExclusive = Math.Min(items.Count, Math.Max(1, lastIndexExclusive));
            if (firstIndexInclusive >= lastIndexExclusive) return;
            
            list.InsertRange(insertAtIndex,
                items.GetRange(firstIndexInclusive, lastIndexExclusive - firstIndexInclusive));
            items.RemoveRange(firstIndexInclusive, lastIndexExclusive - firstIndexInclusive);
        }
    }
