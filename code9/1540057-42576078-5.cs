    public static class Extensions
    {
        public static bool RecursiveCheck<T>(this T rootItem, Func<T, IEnumerable<T>> getChildrenFunc, Func<T, bool> predicate)
        {
            var queue = new Queue<T>();
            queue.Enqueue(rootItem);
            while (queue.Count > 0)
            {
                T current = queue.Dequeue();
                if (predicate(current))
                    return true;
                foreach (T child in getChildrenFunc(current))
                    queue.Enqueue(child);
            }
            return false;
        }
    }
