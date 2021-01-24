    public static class Extensions
    {
        public static List<T> DrainTo<T>(this System.Collections.Concurrent.ConcurrentQueue<T> poConcurrentQueue)
        {
            List<T> loList = new List<T>();
            T loElement;
            while (poConcurrentQueue.TryDequeue(out loElement))
                loList.Add(loElement);
            return loList;
        }
    }
