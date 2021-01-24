    public static class ListExtensions
    {
        public static void Splice<T>(this List<T> list, int insertAtIndex, List<T> items, 
            int first, int last)
        {
            if (items == null) return;
            insertAtIndex = Math.Min(list.Count, Math.Max(0, insertAtIndex));
            first = Math.Min(items.Count - 1, Math.Max(0, first));
            last = Math.Min(items.Count, Math.Max(1, last));
            if (first >= last) return;
            
            list.InsertRange(insertAtIndex, items.GetRange(first, last - first));            
            items.RemoveRange(first, last - first);
        }
    }
