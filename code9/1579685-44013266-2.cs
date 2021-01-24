    public static class ListExtensions
    {
        public static void Splice<T>(this List<T> list, int insertAtIndex, 
            List<T> items, int firstIndexInclusive, int lastIndexExclusive)
        {
            if (items == null) return;
            // Do something if input is invalid. According to the docs, this should not throw
            insertAtIndex = Math.Min(list.Count, Math.Max(0, insertAtIndex));
            firstIndexInclusive = Math.Min(items.Count - 1, Math.Max(0, firstIndexInclusive));
            lastIndexExclusive = Math.Min(items.Count - 1, Math.Max(0, lastIndexExclusive));
            if (firstIndexInclusive > lastIndexExclusive) return;
            list.InsertRange(insertAtIndex,
                items.GetRange(firstIndexInclusive, lastIndexExclusive - firstIndexInclusive));
        }
    }
