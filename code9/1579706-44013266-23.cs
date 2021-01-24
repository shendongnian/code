    public static class ListExtensions
    {
        /// <summary>
        /// Transfers all elements from 'items' into 'this' at the specified index
        /// </summary>
        /// <typeparam name="T">The type of items in the list</typeparam>
        /// <param name="list">'this' instance</param>
        /// <param name="insertAtIndex">The index to insert the items</param>
        /// <param name="items">The list to transfer the items from</param>
        public static void Splice<T>(this List<T> list, int insertAtIndex,
            List<T> items)
        {
            if (items == null) return;
            list.Splice(insertAtIndex, items, 0, items.Count);
        }
        /// <summary>
        /// Transfers the element at 'itemIndex' from 'items' 
        /// into 'this' at the specified index
        /// </summary>
        /// <typeparam name="T">The type of items in the list</typeparam>
        /// <param name="list">'this' instance</param>
        /// <param name="insertAtIndex">The index to insert the item</param>
        /// <param name="items">The list to transfer the item from</param>
        /// <param name="itemIndex">The index of the item to transfer</param>
        public static void Splice<T>(this List<T> list, int insertAtIndex,
            List<T> items, int itemIndex)
        {
            list.Splice(insertAtIndex, items, itemIndex, itemIndex + 1);
        }
        /// <summary>
        /// Transfers the specified range of elements from 'items' 
        /// into 'this' at the specified index
        /// </summary>
        /// <typeparam name="T">The type of items in the list</typeparam>
        /// <param name="list">'this' instance</param>
        /// <param name="insertAtIndex">The index to insert the item</param>
        /// <param name="items">The list to transfer the item from</param>
        /// <param name="first">The index of the first item in the range</param>
        /// <param name="last">The exclusive index of the last item in the range</param>
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
